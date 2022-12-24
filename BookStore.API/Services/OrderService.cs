using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
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
        private readonly ICartService _cartService;

        public OrderService(DataContext context, IOrderReponsitory orderReponsitory, IProductReponsitory productReponsitory, ICartService cartService)
        {
            _cartService = cartService;
            _context = context;
            _orderReponsitory = orderReponsitory;
            _productReponsitory = productReponsitory;
        }

        public ViewOrderDTO UpdateStatus(int idorder, string status)
        {
            var order = _context.Orders.FirstOrDefault(c=>c.IdOrder== idorder);
            var view = new ViewOrderDTO
            {
                Status ="Error",
                Message = "Đơn hàng không tồn tại.",
                data = null
            };
            if(order!= null)
            {
                order.Status = status;
                order.DateOrder = DateTime.Now;
                _orderReponsitory.UpdateOrder(order);
                _orderReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thanh toán thành công.";
                view.data = order;
            }
            return view;
        }
        public ViewOrderDTO UpdateStatusVnPay(int idorder, int vnpay)
        {
            var order = _context.Orders.FirstOrDefault(c=>c.IdOrder== idorder);
            var view = new ViewOrderDTO
            {
                Status ="Error",
                Message = "Đơn hàng không tồn tại.",
                data = null
            };
            if(order!= null)
            {
                if(vnpay == 0 || vnpay == 7 )
                {
                    order.Status = "Paid";
                    order.DateOrder = DateTime.Now;
                    _orderReponsitory.UpdateOrder(order);
                    _orderReponsitory.IsSaveChanges();
                    view.Status = "Success";
                    view.Message = "Thanh toán thành công.";
                    view.data = order;
                }
                else
                {
                    order.Status = "Payment failed";
                    order.DateOrder = DateTime.Now;
                    _orderReponsitory.UpdateOrder(order);
                    _orderReponsitory.IsSaveChanges();
                    view.Status = "Error";
                    view.Message = "Thanh toán thất bại.";
                    view.data = order;
                }
            }
            return view;
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
                order.SDT = orderDTO.SDT;
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
                            NameProduct = _productReponsitory.GetProductsByIdpro(i.IdProduct).Name,
                            Quantity = i.Quantity,
                            Price = i.Price
                        };
                        list.Add(add);
                    };
                }
                var a = _context.Payments.FirstOrDefault(c=>c.IdOrder==order.IdOrder);
                if (a == null)
                {
                    rs.IdOrder = order.IdOrder;
                    rs.Address = order.Address;
                    rs.Status = order.Status;
                    rs.TypePay = null;
                    rs.Total = order.Total;
                    rs.DateOrder = order.DateOrder;
                    rs.orders = list;
                }else
                {
                    var b = _context.MethodPays.FirstOrDefault(c=>c.Id == a.IdPay);
                    if(b == null)
                    {
                        rs.IdOrder = order.IdOrder;
                        rs.Address = order.Address;
                        rs.Status = order.Status;
                        rs.TypePay = null;
                        rs.Total = order.Total;
                        rs.DateOrder = order.DateOrder;
                        rs.orders = list;
                    }else {
                        rs.IdOrder = order.IdOrder;
                        rs.Address = order.Address;
                        rs.Status = order.Status;
                        rs.TypePay = b.TypeName;
                        rs.Total = order.Total;
                        rs.DateOrder = order.DateOrder;
                        rs.orders = list;
                    }                    
                }
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
                        NameProduct = _productReponsitory.GetProductsByIdpro(i.IdProduct).Name,
                        Quantity = i.Quantity,
                        Price = i.Price
                    };
                    list.Add(add);
                };
            }
            return list;
        }

        public View GetOrderByUser(int id, int page, int size)
        {
            var query = _context.Orders.Where(a=>a.IdUser==id).OrderByDescending(b=>b.DateOrder).ToList();
            var view = new View();
            var list2 = new List<OrderView>();
            if(page != 0 && size != 0)
            {
                int total = query.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var data = query.Skip(((page) - 1) * size).Take(size).ToList();
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
                                    NameProduct = _productReponsitory.GetProductsByIdpro(j.IdProduct).Name,
                                    Quantity = j.Quantity,
                                    Price = j.Price
                                };
                                list.Add(add);
                            };
                        }
                        var a = _context.Payments.FirstOrDefault(c=>c.IdOrder==i.IdOrder);
                        var rs = new OrderView();
                        if (a == null)
                        {
                            rs.IdOrder = i.IdOrder;
                            rs.Address = i.Address;
                            rs.Status = i.Status;
                            rs.TypePay = null;
                            rs.Total = i.Total;
                            rs.DateOrder = i.DateOrder;
                            rs.orders = list;
                        }else
                        {
                            var b = _context.MethodPays.FirstOrDefault(c=>c.Id == a.IdPay);
                            if(b == null)
                            {
                                rs.IdOrder = i.IdOrder;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = null;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                                rs.orders = list;
                            }else {
                                rs.IdOrder = i.IdOrder;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = b.TypeName;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                                rs.orders = list;
                            }
                        }
                        list2.Add(rs);
                    }
                }
                view.Page = page;
                view.Size = size;
                view.TotalPage = pagecount;
                view.Data = list2;
            }else{
                if(query != null)
                {
                    foreach (Orders i in query)
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
                                    NameProduct = _productReponsitory.GetProductsByIdpro(j.IdProduct).Name,
                                    Quantity = j.Quantity,
                                    Price = j.Price
                                };
                                list.Add(add);
                            };
                        }
                        var a = _context.Payments.FirstOrDefault(c=>c.IdOrder==i.IdOrder);
                        var rs = new OrderView();
                        if (a == null)
                        {
                            rs.IdOrder = i.IdOrder;
                            rs.Address = i.Address;
                            rs.Status = i.Status;
                            rs.TypePay = null;
                            rs.Total = i.Total;
                            rs.DateOrder = i.DateOrder;
                            rs.orders = list;
                        }else
                        {
                            var b = _context.MethodPays.FirstOrDefault(c=>c.Id == a.IdPay);
                            if(b == null)
                            {
                                rs.IdOrder = i.IdOrder;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = null;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                                rs.orders = list;
                            }else {
                                rs.IdOrder = i.IdOrder;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = b.TypeName;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                                rs.orders = list;
                            }
                        }
                        list2.Add(rs);
                    }
                }
                view.Page = 0;
                view.Size = 0;
                view.TotalPage = 0;
                view.Data = list2;
            }
            return view;
        }

        public ViewDTO GetOrder(int page , int size)
        {
            var query = _context.Orders.ToList();
            var view = new ViewDTO();
            var list = new List<ViewOrderAll>();
            if(page != 0 && size != 0)
            {
                int total = query.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var data = query.Skip(((page) - 1) * size).Take(size).ToList();
                if(data != null)
                {
                    foreach (Orders i in data)
                    {
                        var a = _context.Payments.FirstOrDefault(c=>c.IdOrder==i.IdOrder);
                        var rs = new ViewOrderAll();
                        if (a == null)
                        {
                            rs.IdOrder = i.IdOrder;
                            rs.NameUser =_context.Users.FirstOrDefault(c=>c.IdUser == i.IdUser).Name;
                            rs.Address = i.Address;
                            rs.Status = i.Status;
                            rs.TypePay = null;
                            rs.Total = i.Total;
                            rs.DateOrder = i.DateOrder;
                        }else
                        {
                            var b = _context.MethodPays.FirstOrDefault(c=>c.Id == a.IdPay);
                            if(b == null)
                            {
                                rs.IdOrder = i.IdOrder;
                                rs.NameUser =_context.Users.FirstOrDefault(c=>c.IdUser == i.IdUser).Name;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = null;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                            }else {
                                rs.IdOrder = i.IdOrder;
                                rs.NameUser =_context.Users.FirstOrDefault(c=>c.IdUser == i.IdUser).Name;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = b.TypeName;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                            }
                        }
                        list.Add(rs);
                    }
                }
                List<ViewOrderAll> sort = list.OrderByDescending(a=>a.DateOrder).ToList();
                view.Page = page;
                view.Size = size;
                view.TotalPage = pagecount;
                view.Data = sort;
            }else{
                if(query != null)
                {
                    foreach (Orders i in query)
                    {
                        var a = _context.Payments.FirstOrDefault(c=>c.IdOrder==i.IdOrder);
                        var rs = new ViewOrderAll();
                        if (a == null)
                        {
                            rs.IdOrder = i.IdOrder;
                            rs.NameUser =_context.Users.FirstOrDefault(c=>c.IdUser == i.IdUser).Name;
                            rs.Address = i.Address;
                            rs.Status = i.Status;
                            rs.TypePay = null;
                            rs.Total = i.Total;
                            rs.DateOrder = i.DateOrder;
                        }else
                        {
                            var b = _context.MethodPays.FirstOrDefault(c=>c.Id == a.IdPay);
                            if(b == null)
                            {
                                rs.IdOrder = i.IdOrder;
                                rs.NameUser =_context.Users.FirstOrDefault(c=>c.IdUser == i.IdUser).Name;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = null;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                            }else {
                                rs.IdOrder = i.IdOrder;
                                rs.NameUser =_context.Users.FirstOrDefault(c=>c.IdUser == i.IdUser).Name;
                                rs.Address = i.Address;
                                rs.Status = i.Status;
                                rs.TypePay = b.TypeName;
                                rs.Total = i.Total;
                                rs.DateOrder = i.DateOrder;
                            }
                        }
                        list.Add(rs);
                    }
                }
                List<ViewOrderAll> sort = list.OrderByDescending(a=>a.DateOrder).ToList();
                view.Page = 0;
                view.Size = 0;
                view.TotalPage = 0;
                view.Data = sort;
            }
            return view;
        }

        public Income GetIncome(int date, int page, int size)
        {
            var income = _orderReponsitory.GetIncomeByPrice(date);
            var view = new Income();
            if(page != 0 && size != 0)
            {
                int total = income.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var orderby = income.OrderByDescending(c=>c.Total);
                var data = orderby.Skip(((page) - 1) * size).Take(size).ToList();
                if (data != null)
                {
                    view.Page = page;
                    view.Size = size;
                    view.TotalPage = pagecount;
                    view.Data = data;
                }
            }else{
                if (income != null)
                {
                    view.Page = 0;
                    view.Size = 0;
                    view.TotalPage = 0;
                    view.Data = income;
                }
            }
            return view;
        }

        public ViewOrders CreateOrderByCart(OrderDTO orderDTO)
        {
            var user = _context.Carts.FirstOrDefault(a=>a.IdUser == orderDTO.IdUser);
            var cart = _context.CartItems.Where(b=>b.IdCart == user.Id).ToList();
            var order = new Orders();
            var orderv1 = new ViewOrders()
            {
                Status= "Error",
                Message= "User không tồn tại",
                data = null
            };
            if (user != null)
            {
                order.IdUser = orderDTO.IdUser;
                order.Address = orderDTO.Address;
                order.SDT = orderDTO.SDT;
                order.Status = "Wait for pay";
                order.DateOrder = DateTime.Now; 
                _orderReponsitory.InsertOrder(order);
                _orderReponsitory.IsSaveChanges();
                var tem = _orderReponsitory.GetOrdersId(order.IdOrder);
                var list = new List<OrderProductAPI>();
                var data = new OrdersViewDTO();
                foreach(CartItem i in cart)
                {
                    decimal total = 0;
                    var pro = _productReponsitory.GetProductsByIdpro(i.IdProduct);
                    decimal pri = (pro.Price) * (1-pro.Discount) * ((int)i.Quantity);
                    var product = new OrderProduct
                    {
                        IdOrder = order.IdOrder,
                        IdProduct = i.IdProduct,
                        Quantity = i.Quantity,
                        Price = pri
                    };
                    _orderReponsitory.InsertOrderProduct(product);
                    _orderReponsitory.IsSaveChanges();
                    var products = new OrderProductAPI
                    {
                        IdOrder = product.IdOrder,
                        IdProduct = product.IdProduct,
                        NameProduct = pro.Name,
                        Quantity = product.Quantity,
                        Price = product.Price
                    };
                    list.Add(products);
                    var orders = _orderReponsitory.GetOrderProductId(order.IdOrder).ToList();
                    foreach (OrderProduct j in orders)
                    {
                        total += ((decimal)j.Price);
                    }
                    tem.Total = total;
                    _orderReponsitory.UpdateOrder(tem);
                    _orderReponsitory.IsSaveChanges();
                    _cartService.DeleteItem(i.Id);
                }
                var ord = _orderReponsitory.GetOrdersId(order.IdOrder);
                data.IdOrder = ord.IdOrder;
                data.IdUser = ord.IdUser;
                data.Address = ord.Address;
                data.SDT = ord.SDT;
                data.Status = ord.Status;
                data.Total = ord.Total;
                data.products = list;
                orderv1.Status = "Success";
                orderv1.Message = "Thành công";
                orderv1.data = data;
            }            
            return orderv1;
        }

        public View GetOrderByDate(int date, int page, int size)
        {
            var Sta = "Paid";
            var pay = _context.Orders.Where(s=> s.Status == Sta).ToList();
            var listpay = new List<Orders>();
            foreach(Orders a in pay)
            {
                TimeSpan time = DateTime.Now - a.DateOrder;
                int day = time.Days;
                if(day <= date)
                {
                    listpay.Add(a);
                }
            }
            var list = new List<OrderView>();
            foreach(var i in listpay)
            { 
                var a = _context.Payments.FirstOrDefault(c=>c.IdOrder== i.IdOrder);
                var tem = new OrderView();
                if(a == null)
                {
                    tem.IdOrder = i.IdOrder;
                    tem.Address = i.Address;
                    tem.Status = i.Status;
                    tem.SDT = i.SDT;
                    tem.TypePay = null;
                    tem.Total = i.Total;
                    tem.DateOrder = i.DateOrder;
                    tem.orders = null;
                    list.Add(tem);
                }else
                {
                    var b = _context.MethodPays.FirstOrDefault(c=>c.Id == a.IdPay);
                    if(b == null)
                    {
                        tem.IdOrder = i.IdOrder;
                        tem.Address = i.Address;
                        tem.Status = i.Status;
                        tem.SDT = i.SDT;
                        tem.TypePay = null;
                        tem.Total = i.Total;
                        tem.DateOrder = i.DateOrder;
                        tem.orders = null;
                    }else {
                        tem.IdOrder = i.IdOrder;
                        tem.Address = i.Address;
                        tem.Status = i.Status;
                        tem.SDT = i.SDT;
                        tem.TypePay = b.TypeName;
                        tem.Total = i.Total;
                        tem.DateOrder = i.DateOrder;
                        tem.orders = null;
                    }
                }
            }
            var view = new View();
            if(page != 0 && size != 0)
            {
                int total = list.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var orderby = list.OrderByDescending(c=>c.DateOrder);
                var data = orderby.Skip(((page) - 1) * size).Take(size).ToList();
                if (data != null)
                {
                    view.Page = page;
                    view.Size = size;
                    view.TotalPage = pagecount;
                    view.Data = data;
                }
            }else{
                if (list != null)
                {
                    view.Page = 0;
                    view.Size = 0;
                    view.TotalPage = 0;
                    view.Data = list;
                }
            }
            
            return view;
        }
    }
}