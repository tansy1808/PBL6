using BookStore.API.Data.Enities.Order;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;

namespace BookStore.API.Services
{
    public interface IOrderService
    {
        ViewOrderDTO CreateOrder(OrderDTO orderDTO);
        ViewOrderProductDTO CreateOrderProduct(OrderProductDTO orderProductDTO);
        ViewOrderPayDTO CreatePay(PaymentDTO paymentDTO);
        ViewProductMethodDTO CreateMethodPay(MethodPayDTO methodPayDTO);
        Orders DeleteOrder(int id);
        OrderView FindOrderById(int id);
        List<OrderProductAPI> FindOrderProductById(int id);
        List<OrderView> GetOrder();
        
    }
}