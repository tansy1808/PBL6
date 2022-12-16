using BookStore.API.Data;
using BookStore.API.Data.Enities.Order;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;
using BookStore.API.Services;
using System.Net;

namespace BookStore.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IOrderReponsitory _orderReponsitory;
        private readonly IProductReponsitory _productReponsitory;

        public OrderService(DataContext context, IOrderReponsitory orderReponsitory, IProductReponsitory productReponsitory)
        {
            _context = context;
            _orderReponsitory = orderReponsitory;
            _productReponsitory = productReponsitory;
        }

        public MethodPay CreateMethodPay(MethodPayDTO methodPayDTO)
        {
            var mpay = new MethodPay
            {
                TypeName = methodPayDTO.TypeName
            };
            _orderReponsitory.InsertMethodPay(mpay);
            _orderReponsitory.IsSaveChanges();
            return mpay;
        }

        public Orders CreateOrder(OrderDTO orderDTO)
        {
            var order = new Orders
            {
                IdUser = orderDTO.IdUser,
                Address = orderDTO.Address,
                Status = "Wait for pay",
                DateOrder = DateTime.Now
            };
            _orderReponsitory.InsertOrder(order);
            _orderReponsitory.IsSaveChanges();
            return order;
        }

        public OrderProduct CreateOrderProduct(OrderProductDTO orderProductDTO)
        {
            var tem = _orderReponsitory.GetOrdersId(orderProductDTO.IdOrder);
            int total = 0;
            var pro =   _productReponsitory.GetProductsByIdpro(orderProductDTO.IdProduct);
            int pri = ((int)pro.Price) * ((int)orderProductDTO.Quantity);
            var order = new OrderProduct
            {
                IdOrder = orderProductDTO.IdOrder,
                IdProduct = orderProductDTO.IdProduct,
                Quantity = orderProductDTO.Quantity,
                Price = pri
            };
            _orderReponsitory.InsertOrderProduct(order);
            _orderReponsitory.IsSaveChanges();
            var orders = _orderReponsitory.GetOrderProductId(orderProductDTO.IdOrder);
            foreach (OrderProduct i in orders)
            {
                total += ((int)i.Price);
            }
            tem.Total = total;
            _orderReponsitory.UpdateOrder(tem);
            _orderReponsitory.IsSaveChanges();
            return order;
        }

        public Payment CreatePay(PaymentDTO paymentDTO)
        {
            var pay = new Payment
            {
                IdOrder = paymentDTO.IdOrder,
                Amount = paymentDTO.Amount,
                TypePay = paymentDTO.TypePay
            };
            _orderReponsitory.InsertPayment(pay);
            _orderReponsitory.IsSaveChanges();
            return pay;
        }

        public Orders DeleteOrder(int id)
        {
            var order = _orderReponsitory.GetOrdersId(id);
            if (order != null) throw new UnauthorizedAccessException("Không có sản phẩm");
            var orderitem = _orderReponsitory.GetOrderProductId(id);
            foreach(OrderProduct i in orderitem)
            {
                _orderReponsitory.DeleteItem(i);            
            }
            _orderReponsitory.DeleteOrders(order);
            _orderReponsitory.IsSaveChanges();
            return order;
        }

        public OrderView FindOrderById(int id)
        {
            var order = _orderReponsitory.GetOrdersId(id);
            var item = _orderReponsitory.GetOrderProductId(order.IdOrder);
            var list = new List<OrderProductAPI>();
            foreach( OrderProduct i in item)
            {
                var add = new OrderProductAPI
                {
                    IdOrder = i.IdOrder,
                    IdProduct = i.IdProduct,
                    Quantity =  i.Quantity,
                    Price = i.Price
                };
                list.Add(add);
            };
            var rs = new OrderView
            {
                IdOrder = order.IdOrder,
                Address = order.Address,
                Status= order.Status,
                Total = order.Total,
                DateOrder = order.DateOrder,
                orders = list
            };
            return rs;
            
        }

        public List<OrderProductAPI> FindOrderProductById(int id)
        {
            var item = _orderReponsitory.GetOrderProductId(id);
            var list = new List<OrderProductAPI>();
            foreach (OrderProduct i in item)
            {
                var add = new OrderProductAPI
                {
                    IdOrder = i.IdOrder,
                    IdProduct = i.IdProduct,
                    Quantity = i.Quantity,
                    Price = i.Price
                };
                list.Add(add);
            };
            return list;
        }

        public List<OrderView> GetOrder()
        {
            var order = _orderReponsitory.GetAllOrders();
            var list = new List<OrderProductAPI>();
            var list2 = new List<OrderView>();
            foreach (Orders i in order)
            {
                var item = _orderReponsitory.GetOrderProductId(i.IdOrder);
                
                foreach (OrderProduct j in item)
                {
                    var add = new OrderProductAPI
                    {
                        IdOrder = j.IdOrder,
                        IdProduct = j.IdProduct,
                        Quantity = j.Quantity,
                        Price = j.Price
                    };
                    list.Add(add);
                };
                var rs = new OrderView
                {
                    IdOrder = i.IdOrder,
                    Address = i.Address,
                    Status = i.Status,
                    Total = i.Total,
                    DateOrder = i.DateOrder,
                    orders = list
                };
                list2.Add(rs);
            }
            
            return list2;
        }
    }
}