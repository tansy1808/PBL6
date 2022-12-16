using BookStore.API.Data.Enities.Order;
using BookStore.API.DTO;
using BookStore.API.DTO.Store;
using BookStore.API.DTO.User;
using BookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("order")]
        public IActionResult CreateOrder([FromForm] OrderDTO orderDTOs)
        {
            try
            {
                return Ok(_orderService.CreateOrder(orderDTOs));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("orderProduct")]
        public IActionResult CreateOrderProduct([FromForm] OrderProductDTO orderProductDTOs)
        {
            try
            {
                return Ok(_orderService.CreateOrderProduct(orderProductDTOs));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("payment")]
        public IActionResult CreatePayment([FromForm] PaymentDTO paymentDTOs)
        {
            try
            {
                return Ok(_orderService.CreatePay(paymentDTOs));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("methodPay")]
        public IActionResult CreateMethodPay([FromForm] MethodPayDTO methodPayDTOs)
        {
            try
            {
                return Ok(_orderService.CreateMethodPay(methodPayDTOs));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("order/{id}")]
        public ActionResult<OrderView> FindOrderId(int id)
        {
            var members = _orderService.FindOrderById(id);
            if (members == null) return NotFound();
            return members;
        }

        [HttpGet("orderProduct/{id}")]
        public ActionResult<List<OrderProductAPI>> FindOrderProductId(int id)
        {
            var members = _orderService.FindOrderProductById(id);
            if (members == null) return NotFound();
            return members;
        }

        [HttpGet]
        public ActionResult<List<OrderView>> GetOrder()
        {
            var members = _orderService.GetOrder();
            if (members == null) return NotFound();
            return members;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var members = _orderService.DeleteOrder(id);
            if (members == null) return NotFound();
            return Ok(members);
        }

    }
}
