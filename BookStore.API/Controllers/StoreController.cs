using BookStore.API.Data;
using BookStore.API.Data.Enities.Order;
using BookStore.API.DTOs.Store;
using BookStore.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/Store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public StoreController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpPost("Order")]
        public IActionResult CreateOrder([FromForm] OrderDTOs orderDTOs)
        {
            var order = new Orders
            {
                IdUser = orderDTOs.IdUser,
                Address = orderDTOs.Address,
                Total = orderDTOs.Total,
                Status = "Wait for pay",
                DateOrder = DateTime.Now
            };
            _orderService.InsertOrder(order);
            _orderService.IsSaveChanges();
            return Ok(order);
        }

        [HttpPost("OrderProduct")]
        public IActionResult CreateOrderProduct([FromForm] OrderProductDTOs orderProductDTOs)
        {
            var order = new OrderProduct
            {
                IdOrder = orderProductDTOs.IdOrder,
                IdProduct = orderProductDTOs.IdProduct,
                Quantity = orderProductDTOs.Quantity,
                Price = orderProductDTOs.Price
            };
            _orderService.InsertOrderProduct(order);
            _orderService.IsSaveChanges();
            return Ok();
        }

        [HttpPost("Payment")]
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
            return Ok();
        }

        [HttpPost("MethodPay")]        
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

        [HttpGet("Order/{id}")]
        public IActionResult FindOrderId(int id)
        {
            var order = _orderService.GetOrdersId(id);
            return Ok(order);
        }

        [HttpGet("OrderProduct/{id}")]
        public IActionResult FindOrderProductId(int id)
        {
            var order = _orderService.GetOrderProductId(id);
            return Ok(order);
        }

        [HttpGet("Payment/{id}")]
        public IActionResult FindPayId(int id)
        {
            var order = _orderService.GetPaymentId(id);
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrder() => Ok(_orderService.GetAllOrders());

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