using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public string Login(AuthUserLogin authUserLogin)
        {
            authUserLogin.Username = authUserLogin.Username.ToLower();
            var currentUser = _context.Users
                .FirstOrDefault(u => u.Username == authUserLogin.Username);
            if (currentUser == null)
            {
                return UnauthorizedAccessException("Username is invalid.");
            }
            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(authUserLogin.Password)
            );
            for (int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if (currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    return UnauthorizedAccessException("Password is invalid.");
                }
            }
            
            return _tokenService.CreateToken(currentUser.Username);
        }

        public string Register(AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_context.Users.Any(u => u.Username == authUserDto.Username))
            {
                return BadHttpRequestException("This username already exists!");
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
                Email = authUserDto.Email,
                RoleId = authUserDto.RoleId
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return _tokenService.CreateToken(user.Username);
        }

        private string BadHttpRequestException(string v)
        {
            throw new NotImplementedException();
        }
        public User getUserId(int id)
        {
            return _context.Users.FirstOrDefault(c => c.IdUser == id);
        }
        private string UnauthorizedAccessException(string v)
        {
            throw new NotImplementedException();
        }
    }
}