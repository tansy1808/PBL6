using BookStore.API.Data;
using BookStore.API.Data.Enities.Order;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;

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

        public ViewProductMethodDTO CreateMethodPay(MethodPayDTO methodPayDTO)
        {
            var view = new ViewProductMethodDTO();
            var mpay = new MethodPay
            {
                TypeName = methodPayDTO.TypeName
            };
            _orderReponsitory.InsertMethodPay(mpay);
            _orderReponsitory.IsSaveChanges();
            view.Status = "Success";
            view.Message = "Thành công";
            view.data = mpay;
            return view;
        }

        public ViewOrderDTO CreateOrder(OrderDTO orderDTO)
        {
            var user = _context.Users.FirstOrDefault(c=> c.IdUser == orderDTO.IdUser);
            var order = new Orders();
            var view = new ViewOrderDTO()
            {
                Status= "Error",
                Message= "User không tồn tại",
                data = null
            };
            if (user != null)
            {
                order.IdUser = orderDTO.IdUser;
                order.Address = orderDTO.Address;
                order.Status = "Wait for pay";
                order.DateOrder = DateTime.Now; 
                _orderReponsitory.InsertOrder(order);
                _orderReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.data = order;
            }            
            return view;
        }

        public ViewOrderProductDTO CreateOrderProduct(OrderProductDTO orderProductDTO)
        {
            var tem = _orderReponsitory.GetOrdersId(orderProductDTO.IdOrder);
            var order = new OrderProduct();
            var view = new ViewOrderProductDTO()
            {
                Status= "Error",
                Message= "Đơn hàng không tồn tại.",
                data = null
            };
            if (tem != null)
            {
                int total = 0;
                var pro = _productReponsitory.GetProductsByIdpro(orderProductDTO.IdProduct);
                view.Status = "Error";
                view.Message = "Sản phẩm không tồn tại hoặc không có trong đơn hàng.";
                view.data = order;
                if(pro != null)
                {
                    int pri = (((int)pro.Price) / 100) * (100-(int)pro.Discount) * ((int)orderProductDTO.Quantity);
                    order.IdOrder = orderProductDTO.IdOrder;
                    order.IdProduct = orderProductDTO.IdProduct;
                    order.Quantity = orderProductDTO.Quantity;
                    order.Price = pri;
                    _orderReponsitory.InsertOrderProduct(order);
                    _orderReponsitory.IsSaveChanges();
                }
                var orders = _orderReponsitory.GetOrderProductId(orderProductDTO.IdOrder);
                if(orders != null)
                {
                    foreach (OrderProduct i in orders)
                    {
                        total += ((int)i.Price);
                    }
                    tem.Total = total;
                    _orderReponsitory.UpdateOrder(tem);
                    _orderReponsitory.IsSaveChanges();
                    view.Status = "Success";
                    view.Message = "Thành công";
                    view.data = order;
                }
            }
            return view;  
        }

        public ViewOrderPayDTO CreatePay(PaymentDTO paymentDTO)
        {
            var order = _context.Orders.FirstOrDefault(c => c.IdOrder == paymentDTO.IdOrder);
            var view = new ViewOrderPayDTO()
            {
                Status= "Error",
                Message= "Đơn hàng không tồn tại",
                data = null
            };
            var pay = new Payment();
            if (order != null)
            {
                pay.IdOrder = paymentDTO.IdOrder;
                pay.Amount = order.Total;
                pay.Date = DateTime.Now;
                pay.TypePay = paymentDTO.TypePay;
                _orderReponsitory.InsertPayment(pay);
                _orderReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.data = pay;
            }
            return view;
        }

        public Orders DeleteOrder(int id)
        {
            var order = _orderReponsitory.GetOrdersId(id);
            if (order != null)
            {
                var orderitem = _orderReponsitory.GetOrderProductId(id);
                if (orderitem != null)
                {
                    foreach (OrderProduct i in orderitem)
                    {
                        _orderReponsitory.DeleteItem(i);
                    }
                }
                _orderReponsitory.DeleteOrders(order);
                _orderReponsitory.IsSaveChanges();
                return order;
            }
            return order;
            
        }

        public OrderView FindOrderById(int id)
        {
            var order = _orderReponsitory.GetOrdersId(id);
            var list = new List<OrderProductAPI>();
            var rs = new OrderView();
            if (order!= null)
            {
                var item = _orderReponsitory.GetOrderProductId(order.IdOrder);
                if (item != null)
                {
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
                }
                rs.IdOrder = order.IdOrder;
                rs.Address = order.Address;
                rs.Status = order.Status;
                rs.Total = order.Total;
                rs.DateOrder = order.DateOrder;
                rs.orders = list;
            }
            return rs;  
        }

        public List<OrderProductAPI> FindOrderProductById(int id)
        {
            var item = _orderReponsitory.GetOrderProductId(id);
            var list = new List<OrderProductAPI>();
            if(item != null)
            {
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
            }
            return list;
        }

        public View GetOrder(int page , int size)
        {
            var query = _context.Orders;
            int total = query.Count();
            int pagecount = total / size;
            float Page = total % size;
            if (Page > 0) { pagecount = pagecount + 1; }
            var data = query.Skip(((page) - 1) * size).Take(size).ToList();
            var list2 = new List<OrderView>();
            if(data != null)
            {
                foreach (Orders i in data)
                {
                    var item = _orderReponsitory.GetOrderProductId(i.IdOrder);
                    var list = new List<OrderProductAPI>();
                    if(item != null)
                    {
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
                    }
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
            }
            var view = new View() 
            {
                Page = page,
                Size = size,
                TotalPage = pagecount,
                Data = list2
            };
            return view;
        }

        public Income GetIncome(int page, int size)
        {
            var income = _orderReponsitory.GetIncomeByPrice();
            int total = income.Count();
            int pagecount = total / size;
            float Page = total % size;
            if (Page > 0) { pagecount = pagecount + 1; }
            var orderby = income.OrderByDescending(c=>c.Total);
            var data = orderby.Skip(((page) - 1) * size).Take(size).ToList();
            var view = new Income();
            if (data != null)
            {
                view.Page = page;
                view.Size = size;
                view.TotalPage = pagecount;
                view.Data = data;
            }
            return view;
        }
    }
}