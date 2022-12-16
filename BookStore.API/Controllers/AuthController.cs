using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BookStore.API.Services.IServices;
namespace BookStore.API.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController( IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthUserDto authUserDto)
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
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpPut("image/{id}")]
        public IActionResult UpdateUserImage(int id, UserImage userImage)
        {
            var user = _authService.getUserId(id);
            if(user != null)
            {
                user.UserImage = userImage.Userimage;
                _authService.UpdateUser(user);
                _authService.IsSaveChanges();
                return Ok(user);
            }
            return Ok();
        }

        //[Authorize]
        [HttpPost("pay")]
        public IActionResult CreatePay([FromForm] PayUserDto payUserDto)
        {
            var userpay = new UserPay
            {
                UserId = payUserDto.UserId,
                PayType = payUserDto.PayType
            };
            _authService.InsertUser(userpay);
            _authService.IsSaveChanges();

            return Ok(userpay.UserId);
        }

        //[Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
	        return RedirectToAction("Index", "Home");
        }

        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, AuthUpdateDto authUserDto)
        {
            var user = _authService.getUserId(id);
            if (user != null)
            {
                user.Name = authUserDto.Name;
                user.Address = authUserDto.Address;
                user.Contact = authUserDto.Contact;
                user.Email = authUserDto.Email; 
                _authService.UpdateUser(user);
                _authService.IsSaveChanges();
                return Ok(user);
            }
            return Ok();
        }
        [HttpPut("password/{id}")]
        public IActionResult Changepass(int id, ChangePass changePass)
        {
            try
            {
                return Ok(_authService.Change(id, changePass));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}