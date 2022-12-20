using BookStore.API.Data.Enities.Order;
using BookStore.API.DTO;

namespace BookStore.API.DATA.Reponsitories
{
    public interface IOrderReponsitory
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
        List<Thongke> GetIncomeByPrice(int date);
        void DeleteOrders(Orders orders);
        void DeleteItem(OrderProduct orderProduct);
        bool IsSaveChanges();
    }
}
