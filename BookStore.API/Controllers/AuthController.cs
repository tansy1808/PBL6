using System.Security.Cryptography;
using System.Text;
using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace BookStore.API.Controllers
{

    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_context.Users.Any(u => u.Username == authUserDto.Username))
            {
                return BadRequest("This username already exists!");
            }
            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(authUserDto.Password);
            var user = new User
            {
                Username = authUserDto.Username,
                PasswordHash = hmac.ComputeHash(passwordBytes),
                PasswordSalt = hmac.Key,
                Name = authUserDto.Name,
                Address = authUserDto.Address,
                Contact = authUserDto.Contact,
                RoleId = authUserDto.RoleId
            };
            _context.Users.Add(user);
            _context.SaveChanges();
 
            var token = _tokenService.CreateToken(user.Username);
            return Ok(token);
        }

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

        [HttpPost("login")]
        public IActionResult Login([FromForm] AuthUserLogin authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            var currentUser = _context.Users
                .FirstOrDefault(u => u.Username == authUserDto.Username);          
            if (currentUser == null)
            {
                return Unauthorized("Username is invalid.");
            }
            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(authUserDto.Password)
            );
            for (int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if(currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    return Unauthorized("Password is invalid.");
                }
            }
            var token = _tokenService.CreateToken(currentUser.Username);
            return Ok(token);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
	        return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, AuthUserDto authUserDto)
        {
            var user = _context.Users.FirstOrDefault(c => c.IdUser == id);
            if(user != null)
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
//        [Authorize]
        [HttpGet]
        public IActionResult Get() => Ok(_context.Users.ToList());
    }
}