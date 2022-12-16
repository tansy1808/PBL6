using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.DTO.Cart;
using BookStore.API.DTO.User;
using BookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult CreateCart([FromForm] CartDTO cartDTO)
        {
            try
            {
                return Ok(_cartService.AddCart(cartDTO));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cartItem")]
        public IActionResult CreateCartItem([FromForm] CartItemDTO cartItemDTOs)
        {
            try
            {
                return Ok(_cartService.AddCartItem(cartItemDTOs));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CartView> GetCartId(int id)
        {
            var members = _cartService.GetCartId(id);
            if (members == null) return NotFound();
            return members;
        }

        [HttpDelete("cartItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var members = _cartService.DeleteItem(id);
            if (members == null) return NotFound();
            return Ok(members);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_cartService.DeleteCart(id));
        }

    }
}
