using System.Security.Cryptography;
using System.Text;
using BookStoreAPI.DATA;
using BookStoreAPI.DATA.Reponsitories.IR;
using BookStoreAPI.DTO;
using BookStoreAPI.DTO.Email;
using BookStoreAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/vnpay")]
    public class VnPayController : Controller
    {
        private readonly IVnpayServices _vnpayServices;
        private readonly IUserReponsitory _userReponsitory;

        public VnPayController(IVnpayServices vnpayServices, IUserReponsitory userReponsitory)
        {
            _vnpayServices = vnpayServices;
            _userReponsitory = userReponsitory;
        }

        [HttpPost]
        public ActionResult CreateVnpay(int id, [FromBody] OrderVnpay orderVnpay, string returnUrl)
        {
            var a = _vnpayServices.CreateOrder(id,orderVnpay, returnUrl);
            return Ok(a);
        }

        [HttpGet("send/{email}")]
        public ActionResult<ViewBag> Get(string email)
        {
            var rng = new Random();
            var view = new ViewBag();
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            char c;
            for (int i = 0; i < 15; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65,87)));
                sb.Append(c);
            }
            var pass = sb.ToString();
            var user = _userReponsitory.GetUserByEmail(email);
            using var hmac = new HMACSHA512();
            var password = Encoding.UTF8.GetBytes(pass);
            if (user != null)
            {
                user.PasswordHash = hmac.ComputeHash(password);
                user.PasswordSalt = hmac.Key;
                _userReponsitory.UpdateUser(user);
                _userReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.Title = pass;
                view.data = null;
                var ms = "Xin cảm ơn bạn ủng hộ cho cửa hàng. Đây là mật khẩu mới của bạn:"+ pass;
                var message = new Message(new string[] { email }, "HIKARU SHOP", ms);
                _vnpayServices.SendEmail(message);

            }else{
                view.Status = "Error";
                view.Message = "Email không tồn tại.";
                view.Title = null;
                view.data = null;
            }
            return view;
        }
    }
}