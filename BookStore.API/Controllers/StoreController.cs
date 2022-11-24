using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.Data.Enities.Order;
using BookStore.API.DTOs.Cart;
using BookStore.API.DTOs.Store;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/Store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly DataContext _context;
        public StoreController(DataContext context)
        {
            _context = context;
        }
        
        [HttpPost("Order")]
        public IActionResult CreateOrder([FromForm] OrderDTOs orderDTOs)
        {
            var order = new Orders
            {
                IdUser = orderDTOs.IdUser,
                Address = orderDTOs.Address,
                Total = orderDTOs.Total
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok();
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
            _context.OrderProducts.Add(order);
            _context.SaveChanges();
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
            _context.Payments.Add(pay);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("MethodPay")]
        public IActionResult CreateMethodPay([FromForm] MethodPayDTOs methodPayDTOs)
        {
            var mpay = new MethodPay
            {
                TypeName = methodPayDTOs.TypeName
            };
            _context.MethodPays.Add(mpay);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("Order/{id}")]
        public IActionResult FindOrderId(int id)
        {
            var order = _context.Orders.Where(c => c.IdOrder == id).ToList();
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrder() => Ok(_context.Orders.ToList());

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(c => c.IdOrder == id);
            if (order != null)
            {
                var orderitem = _context.OrderProducts.FirstOrDefault(c => c.IdOrder == id);
                _context.OrderProducts.Remove(orderitem);
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Ok(order);
            }
            return Unauthorized("Không có sản phẩm");
        }
    }
}