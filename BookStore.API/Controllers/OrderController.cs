using BookStore.API.DTO;
using BookStore.API.DTO.Store;
using BookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Customer,Admin")]
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

        [Authorize(Roles = "Customer,Admin")]
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

        [Authorize(Roles = "Customer,Admin")]
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

        [Authorize(Roles = "Customer,Admin")]
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

        [Authorize(Roles = "Customer,Admin")]
        [HttpPost("")]
        public ActionResult<ViewOrders> CreateOrdersByCart(OrderDTO orderDTO)
        {
            try
            {
                return Ok(_orderService.CreateOrderByCart(orderDTO));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Find/{id}")]
        public ActionResult<OrderView> FindOrderId(int id)
        {
            var members = _orderService.FindOrderById(id);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("{iduser}")]
        public ActionResult<View> GetOrder(int iduser, int page, int size)
        {
            var members = _orderService.GetOrderByUser(iduser,page,size);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Income/{date}")]
        public ActionResult<Income> GetPrice(int date,int page, int size)
        {
            var members = _orderService.GetIncome(date,page,size);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var members = _orderService.DeleteOrder(id);
            if (members == null) return NotFound();
            return Ok(members);
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpPut("{idorder}")]
        public ActionResult<ViewOrderDTO> UpdateOrder(int idorder, int vnpay)
        {
            var members = _orderService.UpdateStatus(idorder,vnpay);
            if (members == null) return NotFound();
            return Ok(members);
        }
    }
}
