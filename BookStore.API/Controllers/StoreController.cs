using BookStore.API.Data;
using BookStore.API.Data.Enities.Order;
using BookStore.API.DTOs.Store;
using BookStore.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public StoreController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }
        
        [HttpPost("order")]
        public IActionResult CreateOrder([FromForm] OrderDTOs orderDTOs)
        {
            var order = new Orders
            {
                IdUser = orderDTOs.IdUser,
                Address = orderDTOs.Address,
                Status = "Wait for pay",
                DateOrder = DateTime.Now
            };
            _orderService.InsertOrder(order);
            _orderService.IsSaveChanges();
            return Ok(order);
        }

        [HttpPost("orderProduct")]
        public IActionResult CreateOrderProduct([FromForm] OrderProductDTOs orderProductDTOs)
        {
            var tem = _orderService.GetOrdersId(orderProductDTOs.IdOrder);
            int total = 0;
            var pro = _productService.GetProductsById(orderProductDTOs.IdProduct);
            int pri = ((int)pro.Price) * ((int)orderProductDTOs.Quantity);
            var order = new OrderProduct
            {
                IdOrder = orderProductDTOs.IdOrder,
                IdProduct = orderProductDTOs.IdProduct,
                Quantity = orderProductDTOs.Quantity,
                Price = pri
            };
            _orderService.InsertOrderProduct(order);
            _orderService.IsSaveChanges();
            var orders = _orderService.GetOrderProductId(orderProductDTOs.IdOrder);
            foreach (OrderProduct i in orders)
            {
                total += ((int)i.Price);
            }
            tem.Total = total;
            _orderService.UpdateOrder(tem);
            _orderService.IsSaveChanges();
            return Ok(tem);
        }

        [HttpPost("payment")]
        public IActionResult CreatePayment([FromForm] PaymentDTOs paymentDTOs)
        {
            var pay = new Payment
            {
                IdOrder = paymentDTOs.IdOrder,
                Amount = paymentDTOs.Amount,
                TypePay = paymentDTOs.TypePay
            };
            _orderService.InsertPayment(pay);
            _orderService.IsSaveChanges();
            return Ok(pay);
        }

        [HttpPost("methodPay")]        
        public IActionResult CreateMethodPay([FromForm] MethodPayDTOs methodPayDTOs)
        {
            var mpay = new MethodPay
            {
                TypeName = methodPayDTOs.TypeName
            };
            _orderService.InsertMethodPay(mpay);
            _orderService.IsSaveChanges();
            return Ok();
        }

        [HttpGet("order/{id}")]
        public IActionResult FindOrderId(int id)
        {
            var order = _orderService.GetOrdersId(id);
            return Ok(order);
        }

        [HttpGet("orderProduct/{id}")]
        public IActionResult FindOrderProductId(int id)
        {
            var order = _orderService.GetOrderProductId(id);
            return Ok(order);
        }

        [HttpGet("payment/{id}")]
        public IActionResult FindPayId(int id)
        {
            var order = _orderService.GetPaymentId(id);
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(_orderService.GetAllOrders()); ;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderService.GetOrdersId(id);
            if (order != null)
            {
                var orderitem = _orderService.GetOrderProductId(id);
                _orderService.DeleteItem(orderitem);
                _orderService.DeleteOrders(order);
                _orderService.IsSaveChanges();
                return Ok(order);
            }
            return Unauthorized("Không có sản phẩm");
        }
    }
}