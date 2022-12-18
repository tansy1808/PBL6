﻿using BookStore.API.Data;
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
        public IActionResult CreateCartItem([FromForm] AddItemDTO addItemDTO)
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
        public IActionResult UpdateItem(int iditem, CartItemView cartItemView)
        {
            var members = _cartService.UpdateCartItem(iditem, cartItemView);
            if (members == null) return NotFound();
            return Ok(members);
        }
    }
}
