
using BookStore.API.Data.Enities.Order;
using BookStore.API.DTOs.Store;

namespace BookStore.API.Services.IServices
{
    public interface IOrderService
    {
        void InsertOrder(Orders orders);
        void InsertOrderProduct(OrderProduct orderProduct);
        void InsertPayment(Payment payment);
        void InsertMethodPay(MethodPay methodPay);
        void UpdateOrder(Orders orders);
        List<OrderProduct> GetOrderProductId(int id);
        Payment GetPaymentId(int id);
        Orders GetOrdersId(int id);
        List<Orders> GetAllOrders();
        void DeleteOrders(Orders orders);
        void DeleteItem(List<OrderProduct> orderProduct);
        bool IsSaveChanges();
    }
}