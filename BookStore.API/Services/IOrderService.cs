
using BookStore.API.Data.Enities.Order;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;

namespace BookStore.API.Services
{
    public interface IOrderService
    {
        Orders CreateOrder(OrderDTO orderDTO);
        OrderProduct CreateOrderProduct(OrderProductDTO orderProductDTO);
        Payment CreatePay(PaymentDTO paymentDTO);
        MethodPay CreateMethodPay(MethodPayDTO methodPayDTO);
        Orders DeleteOrder(int id);
        OrderView FindOrderById(int id);
        List<OrderProductAPI> FindOrderProductById(int id);
        List<OrderView> GetOrder();
        
    }
}