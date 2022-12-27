using BookStoreAPI.DATA.Enities.Order;
using BookStoreAPI.DTO;

namespace BookStoreAPI.DATA.Reponsitories.IR
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
        List<Thongke> GetIncomeByPrice(int month, int year);
        void DeleteOrders(Orders orders);
        void DeleteItem(OrderProduct orderProduct);
        bool IsSaveChanges();
    }
}
