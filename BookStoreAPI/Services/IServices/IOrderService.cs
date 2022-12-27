using BookStoreAPI.DATA.Enities.Order;
using BookStoreAPI.DTO;
using BookStoreAPI.DTO.Store;

namespace BookStoreAPI.Services.IServices
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
        ViewDTO GetOrderByStatus(string status, int page, int size);
        OrderView FindOrderById(int id);
        List<OrderProductAPI> FindOrderProductById(int id);
        View GetOrderByUser(int id, int page, int size);
        ViewDTO GetOrder(int page, int size);
        Income GetIncome(int month, int year, int page, int size);
        Orders DeleteOrder(int id);

    }
}