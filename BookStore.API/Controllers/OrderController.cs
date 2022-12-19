using BookStore.API.DTO;
using BookStore.API.DTO.Store;
using BookStore.API.Services;
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
        public ActionResult<ViewOrderDTO> CreateOrder([FromForm] OrderDTO orderDTOs)
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
        public ActionResult<ViewOrderProductDTO> CreateOrderProduct([FromForm] OrderProductDTO orderProductDTOs)
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
        public ActionResult<ViewOrderPayDTO> CreatePayment([FromForm] PaymentDTO paymentDTOs)
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
        public ActionResult<ViewProductMethodDTO> CreateMethodPay([FromForm] MethodPayDTO methodPayDTOs)
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

        [HttpGet("Find/{id}")]
        public ActionResult<OrderView> FindOrderId(int id)
        {
            var members = _orderService.FindOrderById(id);
            if (members == null) return NotFound();
            return members;
        }

        [HttpGet]
        public ActionResult<View> GetOrder(int page, int size)
        {
            var members = _orderService.GetOrder(page,size);
            if (members == null) return NotFound();
            return members;
        }

        [HttpGet("Income")]
        public ActionResult<Income> GetPrice(int page, int size)
        {
            var members = _orderService.GetIncome(page,size);
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
