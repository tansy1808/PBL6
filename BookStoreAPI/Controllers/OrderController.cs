using BookStoreAPI.DTO;
using BookStoreAPI.DTO.Store;
using BookStoreAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
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

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("find/{id}")]
        public ActionResult<OrderView> FindOrderId(int id)
        {
            var members = _orderService.FindOrderById(id);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("{iduser}")]
        public ActionResult<View> GetOrderByUser(int iduser, int page, int size)
        {
            var members = _orderService.GetOrderByUser(iduser,page,size);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("")]
        public ActionResult<ViewDTO> GetOrderAll(int page, int size)
        {
            var members = _orderService.GetOrder(page,size);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("income/{year}")]
        public ActionResult<Income> GetPrice(int month,int year,int page, int size)
        {
            var members = _orderService.GetIncome(month,year,page,size);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("status/{status}")]
        public ActionResult<ViewDTO> GetStatus(string status, int page, int size)
        {
            var members = _orderService.GetOrderByStatus(status, page, size);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("datepay/{date}")]
        public ActionResult<View> GetOrderDate(int date,int page, int size)
        {
            var members = _orderService.GetOrderByDate(date,page,size);
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
        [HttpPut("vnpay/{idorder}")]
        public ActionResult<ViewOrderDTO> UpdateOrderVnPay(int idorder, int vnpay)
        {
            var members = _orderService.UpdateStatusVnPay(idorder,vnpay);
            if (members == null) return NotFound();
            return Ok(members);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{idorder}")]
        public ActionResult<ViewOrderDTO> UpdateOrder(int idorder, string status)
        {
            var members = _orderService.UpdateStatus(idorder,status);
            if (members == null) return NotFound();
            return Ok(members);
        }
    }
}
