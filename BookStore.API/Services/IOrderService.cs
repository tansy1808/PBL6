using BookStore.API.Data.Enities.Order;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;

namespace BookStore.API.Services
{
    public interface IOrderService
    {
        ViewOrderDTO CreateOrder(OrderDTO orderDTO);
        ViewOrderProductDTO CreateOrderProduct(OrderProductDTO orderProductDTO);
        ViewOrders CreateOrderByCart(int iduser, string address);
        ViewOrderPayDTO CreatePay(PaymentDTO paymentDTO);
        ViewProductMethodDTO CreateMethodPay(MethodPayDTO methodPayDTO);
        ViewOrderDTO UpdateStatus(int idorder, int vnpay);
        Orders DeleteOrder(int id);
        OrderView FindOrderById(int id);
        List<OrderProductAPI> FindOrderProductById(int id);
        View GetOrderByUser(int id, int page, int size);
        View GetOrder(int page, int size);
        Income GetIncome(int page, int size);
        
    }
}