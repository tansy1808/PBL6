using System.Security.Cryptography;
using System.Text;
using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.API.Controllers
{

    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly DataContext _context;

        public AuthController(AuthService authService, DataContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] AuthUserDto authUserDto)
        {
            try
            {
                return Ok(_authService.Register(authUserDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromForm] AuthUserLogin authUserLogin)
        {
            try
            {
                return Ok(_authService.Login(authUserLogin));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("Image/{id}")]
        public IActionResult UpdateUserImage(int id, UserImage userImage)
        {
            var user = _authService.getUserId(id);
            if(user != null)
            {
                user.UserImage = userImage.Userimage;
                _context.SaveChanges();
                return Ok(user);
            }
            return Ok();
        }

        [Authorize]
        [HttpPost("pay")]
        public IActionResult CreatePay([FromForm] PayUserDto payUserDto)
        {
            var userpay = new UserPay
            {
                UserId = payUserDto.UserId,
                PayType = payUserDto.PayType
            };
            _context.UserPays.Add(userpay);
            _context.SaveChanges();

            return Ok(userpay.UserId);
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
	        return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, AuthUserDto authUserDto)
        {
            var user = _authService.getUserId(id);
            if (user != null)
            {
                user.Name = authUserDto.Name;
                user.Address = authUserDto.Address;
                user.Contact = authUserDto.Contact;
                user.RoleId = authUserDto.RoleId;
                _context.SaveChangesAsync();
                return Ok(user);
            }
            return Ok();
        }
    }
}