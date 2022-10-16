using BookStore.API.Data;
using BookStore.API.Data.Enities;
using BookStore.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_context.SetUser.Any(u => u.Username == authUserDto.Username))
            {
                return BadRequest("This username already exists!");
            }

            var user = new User
            {
                Username = authUserDto.Username,
                Password = authUserDto.Password,
                Name = authUserDto.Name,
                Address = authUserDto.Address,
                Contact = authUserDto.Contact,
                RoleId = authUserDto.RoleId
            };
            _context.SetUser.Add(user);
            _context.SaveChanges();
 
            return Ok(user.Username);
        }
        [HttpPost("createpay")]
        public IActionResult CreatePay([FromBody] PayUserDto payUserDto)
        {
            var userpay = new UserPay
            {
                UserId = payUserDto.UserId,
                PayType = payUserDto.PayType
            };
            _context.SetPay.Add(userpay);
            _context.SaveChanges();
            
            return Ok(userpay.UserId);
        }

    }
}