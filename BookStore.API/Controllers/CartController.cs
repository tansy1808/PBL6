using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.DTOs.Cart;
using BookStore.API.DTOs.Views;
using BookStore.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly DataContext context;

        public CartController(ICartService cartService, DataContext context)
        {
            _cartService = cartService;
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreateCart([FromForm] CartDTOs cartDTOs)
        {
            var cart = new Carts
            {
                IdUser = cartDTOs.IdUser
            };
            _cartService.InsertCart(cart);
            _cartService.IsSaveChanges();
            return Ok(cart);
        }
        [HttpGet]
        public IActionResult get() { return Ok(context.Carts.ToList()); }

        [HttpGet("{id}")]
        public IActionResult GetCartId(int id)
        {   
            return Ok(_cartService.GetCartsId(id));
        }
        
        [HttpPost("cartItem")]
        public IActionResult CreateCartItem([FromForm] CartItemDTOs cartItemDTOs)
        {
            var cartItem = new CartItem
            {
                IdProduct = cartItemDTOs.IdProduct,
                IdCart = cartItemDTOs.IdCart,
                Quantity = cartItemDTOs.Quantity
            };
            _cartService.InsertCartItem(cartItem);
            _cartService.IsSaveChanges();
            return Ok(cartItem);
        }
        [HttpDelete("cartItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var cartitem = _cartService.GetCartItemId(id);
            if (cartitem != null)
            {
                _cartService.DeleteItem(cartitem);
                _cartService.IsSaveChanges();
                return Ok(cartitem);
            }
            return Unauthorized("Không có sản phẩm");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cart = _cartService.GetCarts(id);
            if (cart != null)
            {
                _cartService.DeleteCart(cart);
                _cartService.IsSaveChanges();
                return Ok(cart);
            }
            return Unauthorized("Không có sản phẩm");
        }
    }
}