using BookStore.API.Data.Enities.Order;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;

namespace BookStore.API.Services
{
    public interface IOrderService
    {
        ViewOrderDTO CreateOrder(OrderDTO orderDTO);
        ViewOrderProductDTO CreateOrderProduct(OrderProductDTO orderProductDTO);
        ViewOrders CreateOrderByCart(OrderDTO orderDTO);
        ViewOrderPayDTO CreatePay(PaymentDTO paymentDTO);
        ViewProductMethodDTO CreateMethodPay(MethodPayDTO methodPayDTO);
        ViewOrderDTO UpdateStatusVnPay(int idorder, int vnpay);
        ViewOrderDTO UpdateStatus(int idorder, string status);
        View GetOrderByDate(int date, int page, int size);
        Orders DeleteOrder(int id);
        OrderView FindOrderById(int id);
        List<OrderProductAPI> FindOrderProductById(int id);
        View GetOrderByUser(int id, int page, int size);
        View GetOrder(int page, int size);
        Income GetIncome(int date,int page, int size);
        
    }
}