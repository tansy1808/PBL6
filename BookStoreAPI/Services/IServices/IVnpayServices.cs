using BookStoreAPI.DTO;
using BookStoreAPI.DTO.Email;

namespace BookStoreAPI.Services.IServices
{
    public interface IVnpayServices
    {
        string CreateOrder(int idorder, OrderVnpay orderVnpay, string returnUrl);
        void SendEmail(Message message);
    }
}