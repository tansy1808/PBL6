using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.DTOs.Cart;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
         private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCart([FromForm] CartDTOs cartDTOs)
        {
            var cart = new Carts
            {
                IdUser = cartDTOs.IdUser
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCartId(int id)
        {
            var cart = _context.CartItems.Where(c => c.IdCart == id).ToList();
            return Ok(cart);
        }
        
        [HttpPost("CartItem")]
        public IActionResult CreateCartItem([FromForm] CartItemDTOs cartItemDTOs)
        {
            var cartItem = new CartItem
            {
                IdProduct = cartItemDTOs.IdProduct,
                IdCart = cartItemDTOs.IdCart,
                Quantity = cartItemDTOs.Quantity
            };
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("CartItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var cartitem = _context.CartItems.FirstOrDefault(c => c.Id == id);
            if (cartitem != null)
            {
                _context.CartItems.Remove(cartitem);
                _context.SaveChanges();
                return Ok(cartitem);
            }
            return Unauthorized("Không có sản phẩm");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
                return Ok(cart);
            }
            return Unauthorized("Không có sản phẩm");
        }
    }
}