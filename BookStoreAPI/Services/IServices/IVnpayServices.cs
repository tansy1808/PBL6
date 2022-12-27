using BookStoreAPI.DTO;

namespace BookStoreAPI.Services.IServices
{
    public interface IVnpayServices
    {
        string CreateOrder(int idorder, OrderVnpay orderVnpay, string returnUrl);
    }
}