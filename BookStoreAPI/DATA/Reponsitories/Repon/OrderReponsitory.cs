using BookStoreAPI.DATA.Enities.Order;
using BookStoreAPI.DATA.Reponsitories.IR;
using BookStoreAPI.DTO;

namespace BookStoreAPI.DATA.Reponsitories.Repon
{
    public class OrderReponsitory : IOrderReponsitory
    {
        private readonly DataContext _context;

        public OrderReponsitory(DataContext context)
        {
            _context = context;
        }

        public void DeleteItem(OrderProduct orderProduct)
        {
            _context.OrderProducts.Remove(orderProduct);
        }

        public void DeleteOrders(Orders orders)
        {
            _context.Orders.Remove(orders);
        }

        public List<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Thongke> GetIncomeByPrice(int month, int year)
        {
            var Sta = "Paid";
            var pay = _context.Orders.Where(s => s.Status == Sta).ToList();
            var income = new List<Orders>();
            if (month == 0)
            {
                income = pay.Where(c => c.DateOrder.Year == year).ToList();
            }
            else
            {
                income = pay.Where(c => c.DateOrder.Month == month).Where(d => d.DateOrder.Year == year).ToList();
            }
            var list = new List<Thongke>();
            var list1 = new List<OrderProduct>();
            if (income == null)
            {
                return list;
            }
            else
            {
                foreach (Orders a in income)
                {
                    var id = _context.OrderProducts.Where(t => t.IdOrder == a.IdOrder).ToList();
                    foreach (OrderProduct b in id)
                    {
                        list1.Add(b);
                    }
                }
                var pro = list1.GroupBy(a => a.IdProduct).ToList();
                foreach (var i in pro)
                {
                    var n = _context.Products.FirstOrDefault(c => c.IdProduct == i.Key);
                    if (n != null)
                    {
                        var tem = new Thongke();
                        tem.Id = i.Key;
                        tem.Name = n.Name;
                        int q = 0;
                        decimal t = 0;
                        foreach (OrderProduct j in i)
                        {
                            q = q + j.Quantity;
                            t = t + j.Price;
                        }
                        tem.Quantity = q;
                        tem.Total = t;
                        list.Add(tem);
                    }
                }
                return list;
            }

        }

        public List<OrderProduct> GetOrderProductId(int id)
        {
            return _context.OrderProducts.Where(c => c.IdOrder == id).ToList();
        }

        public Orders GetOrdersId(int id) => _context.Orders.FirstOrDefault(c => c.IdOrder == id);

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

        public void UpdateOrder(Orders orders)
        {
            _context.Orders.Update(orders);
        }
    }
}
