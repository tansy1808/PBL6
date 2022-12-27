using BookStoreAPI.DATA;
using BookStoreAPI.DTO;
using BookStoreAPI.DTO.Email;
using BookStoreAPI.Services.IServices;
using MailKit.Net.Smtp;
using MimeKit;

namespace BookStoreAPI.Services.Services
{
    public class VnpayServices : IVnpayServices
    {
        private readonly DataContext _context;
        private readonly EmailConfiguration _emailConfig;

        public VnpayServices(DataContext context, EmailConfiguration emailConfig)
        {
            _context = context;
            _emailConfig = emailConfig;
        }

        public string CreateOrder(int idorder, OrderVnpay orderVnpay, string returnUrl)
        {
            string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
            var order = _context.Orders.FirstOrDefault(a => a.IdOrder == idorder);
            var user = _context.Users.FirstOrDefault(b => b.IdUser == order.IdUser);
            string vnp_TmnCode = "0H5J4W0W";
            string vnp_HashSecret = "ILEAMKAJCPLEUMGAAVCSTSLUYKOTFCAP";
            string vnp_Returnurl = returnUrl;
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Total * 100).ToString());
            vnpay.AddRequestData("vnp_BankCode", orderVnpay.Bank);
            vnpay.AddRequestData("vnp_CreateDate", order.DateOrder.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", "13.160.52.202");
            vnpay.AddRequestData("vnp_Locale", orderVnpay.NgonNgu);
            vnpay.AddRequestData("vnp_OrderInfo", orderVnpay.NoiDung);
            vnpay.AddRequestData("vnp_OrderType", orderVnpay.LoaiHH); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.IdOrder.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddHours(30).ToString("yyyyMMddHHmmss"));
            //Billing
            vnpay.AddRequestData("vnp_Bill_Mobile", user.Contact);
            vnpay.AddRequestData("vnp_Bill_Email", user.Email);
            // var fullName = user.Name;
            // if (!String.IsNullOrEmpty(fullName))
            // {
            //     var indexof = fullName.IndexOf(' ');
            //     vnpay.AddRequestData("vnp_Bill_FirstName", fullName.Substring(0, indexof));
            //     vnpay.AddRequestData("vnp_Bill_LastName", fullName.Substring(indexof + 1, fullName.Length - indexof - 1));
            // }
            vnpay.AddRequestData("vnp_Bill_Address", user.Address);
            vnpay.AddRequestData("vnp_Bill_City", "vn");
            vnpay.AddRequestData("vnp_Bill_Country", "vn");
            vnpay.AddRequestData("vnp_Bill_State", "");

            // Invoice

            vnpay.AddRequestData("vnp_Inv_Phone", order.SDT);
            vnpay.AddRequestData("vnp_Inv_Email", user.Email);
            vnpay.AddRequestData("vnp_Inv_Customer", user.Name);
            vnpay.AddRequestData("vnp_Inv_Address", order.Address);
            vnpay.AddRequestData("vnp_Inv_Company", "");
            vnpay.AddRequestData("vnp_Inv_Taxcode", "");
            vnpay.AddRequestData("vnp_Inv_Type", "I");

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            return paymentUrl;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("HikaruShop",_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(emailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}