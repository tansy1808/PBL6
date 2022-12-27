using BookStoreAPI.DATA;
using BookStoreAPI.DTO.Cart;
using BookStoreAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Authorize(Roles = "Customer,Admin")]
    [Route("api/cart")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly DataContext _context;

        public CartController(ICartService cartService, DataContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        [HttpPost]
        public ActionResult<ViewCartDTO> CreateCart([FromForm] CartDTO cartDTO)
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
        public ActionResult<ViewCartItemDTO> CreateCartItem([FromForm] AddItemDTO addItemDTO)
        {
            try
            {
                return Ok(_cartService.AddCartItem(addItemDTO));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{iduser}")]
        public ActionResult<CartView> GetCartId(int iduser)
        {
            var members = _cartService.GetCartId(iduser);
            if (members == null) return NotFound();
            return members;
        }

        [HttpDelete("cartItem/{iditem}")]
        public IActionResult DeleteItem(int iditem)
        {
            var members = _cartService.DeleteItem(iditem);
            if (members == null) return NotFound();
            return Ok(members);
        }

        [HttpDelete("{iduser}")]
        public IActionResult Delete(int iduser)
        {
            return Ok(_cartService.DeleteCart(iduser));
        }

        [HttpPut("cartItem/{iditem}")]
        public ActionResult<ViewCartItemDTO> UpdateItem(int iditem, CartItemView cartItemView)
        {
            var members = _cartService.UpdateCartItem(iditem, cartItemView);
            if (members == null) return NotFound();
            return Ok(members);
        }
    }
}
