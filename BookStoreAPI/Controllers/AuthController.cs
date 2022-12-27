
using BookStoreAPI.DTO;
using BookStoreAPI.DTO.User;
using BookStoreAPI.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public ActionResult<ViewBag> Register([FromBody] AuthUserDTO authUserDto)
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
        public ActionResult<ViewBag> Login([FromForm] AuthUserLogin authUserLogin)
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

        [Authorize(Roles = "Customer,Admin")]
        [HttpPost("pay")]
        public ActionResult<ViewBag> CreatePay([FromForm] PayUserDTO payUserDto)
        {
            try
            {
                return Ok(_authService.CreatePay(payUserDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("")]
        public ActionResult<MemberAPI> GetAll(int page, int size)
        {
            return _authService.GetUserAll(page,size);
        }

        [HttpGet("{username}")]
        public ActionResult<UserDTO> GetUserName(string username)
        {
            var members = _authService.GetUserByUserName(username);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("user/{id}")]
        public ActionResult<UserDTO> GetUserByID(int id)
        {
            var members = _authService.GetUserById(id);
            if (members == null) return NotFound();
            return members;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpPut("{id}")]
        public ActionResult<ViewBag> UpdateInfoUser(int id, AuthUpdateDTO authUserDto)
        {

            return Ok(_authService.UpdateUser(id,authUserDto));
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpPut("image/{id}")]
        public ActionResult<ViewBag> UpdateUserImage(int id, UserImage userImage)
        {

            return Ok(_authService.UpdateImage(id,userImage));
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpPut("password/{id}")]
        public ActionResult<ViewBag> ChangePass(int id, [FromForm] ChangePass changePass)
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
        [HttpPut("forget/{email}")]
        public ActionResult<ViewBag> ForgetPass(string email, string newpass, string repass)
        {
            try
            {
                return Ok(_authService.ChangePass(email,newpass, repass));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
