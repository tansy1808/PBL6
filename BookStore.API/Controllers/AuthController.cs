using API.DatingApp.API.DTO;
using BookStore.API.DTO.User;
using BookStore.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
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
        public IActionResult Register([FromBody] AuthUserDTO authUserDto)
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

        [HttpPost("pay")]
        public IActionResult CreatePay([FromForm] PayUserDTO payUserDto)
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

        [HttpGet]
        public ActionResult<MemberAPI> GetAll()
        {
            return _authService.GetUserAll();
        }

        [HttpGet("{username}")]
        public ActionResult<UserDTO> GetUserName(string username)
        {
            var members = _authService.GetUserByUserName(username);
            if (members == null) return NotFound();
            return members;
        }
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUserName(int id)
        {
            var members = _authService.GetUserById(id);
            if (members == null) return NotFound();
            return members;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInfoUser(int id, AuthUpdateDTO authUserDto)
        {

            return Ok(_authService.UpdateUser(id,authUserDto));
        }

        [HttpPut("image/{id}")]
        public IActionResult UpdateUserImage(int id, UserImage userImage)
        {

            return Ok(_authService.UpdateImage(id,userImage));
        }

        [HttpPut("password/{id}")]
        public IActionResult ChangePass(int id, [FromForm] ChangePass changePass)
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
