using BookStore.API.Data;
using BookStore.API.Data.Enities.Order;
using BookStore.API.Services.IServices;

namespace BookStore.API.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public void DeleteItem(List<OrderProduct> orderProduct)
        {
            foreach (OrderProduct orderitem in orderProduct)
            {
                _context.OrderProducts.Remove(orderitem);
            }
        }

        public void DeleteOrders(Orders orders)
        {
            _context.Orders.Remove(orders);
        }

        public List<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<OrderProduct> GetOrderProductId(int id)
        {
            return _context.OrderProducts.Where(c => c.IdOrder == id).ToList();
        }

        public Orders GetOrdersId(int id)
        {
            return _context.Orders.FirstOrDefault(c => c.IdOrder == id);
        }

        public Payment GetPaymentId(int id)
        {
            return _context.Payments.FirstOrDefault(c => c.IdPay == id);
        }

        public void InsertMethodPay(MethodPay methodPay)
        {
            _context.MethodPays.Add(methodPay);
        }

        public void InsertOrder(Orders orders)
        {
            _context.Orders.Add(orders);
        }

        public void InsertOrderProduct(OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
        }

        public void InsertPayment(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}