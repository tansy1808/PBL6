
using BookStore.API.DTO;

namespace BookStore.API.Services
{
    public interface IVnpayServices
    {
        string CreateOrder(int idorder, OrderVnpay orderVnpay, string returnUrl);
    }
}