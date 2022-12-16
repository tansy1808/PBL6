using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;
using BookStore.API.Services.IServices;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.API.Services.Services
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
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == authUserLogin.Username);
            if (currentUser == null)
            {
                throw new UnauthorizedAccessException("Username is invalid.");
            }
            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(authUserLogin.Password)
            );
            for (int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if (currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    throw new UnauthorizedAccessException("Password is invalid.");
                }
            }
            
            return _tokenService.CreateToken(currentUser.Username);
        }

        public string Change(int id, ChangePass changePass)
        {
            var pass = _context.Users.FirstOrDefault(c => c.IdUser == id);
            using var hmac = new HMACSHA512(pass.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(changePass.Password));
            for (int i = 0; i < pass.PasswordHash.Length; i++)
            {
                if (pass.PasswordHash[i] != passwordBytes[i])
                {
                    throw new UnauthorizedAccessException("Password is invalid.");
                }
                if (changePass.NewPassword == changePass.RePassword)
                {
                    var password = Encoding.UTF8.GetBytes(changePass.Password);
                    pass.PasswordHash = hmac.ComputeHash(passwordBytes);
                    pass.PasswordSalt = hmac.Key;
                    _context.Users.Update(pass);
                    _context.SaveChanges();
                    return _tokenService.CreateToken(pass.Username);
                }
                else throw new UnauthorizedAccessException("Password is unlike.");
            }
            return _tokenService.CreateToken(pass.Username);
        }

        public string Register(AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_context.Users.Any(u => u.Username == authUserDto.Username))
            {
                throw new BadHttpRequestException("This username already exists!");
            }
            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(authUserDto.Password);
            var user = new User
            {
                Username = authUserDto.Username,
                PasswordHash = hmac.ComputeHash(passwordBytes),
                PasswordSalt = hmac.Key,
                Name = authUserDto.Name,
                Email = authUserDto.Email,
                RoleId = 2
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return _tokenService.CreateToken(user.Username);
        }

        public User getUserId(int id) => _context.Users.FirstOrDefault(c => c.IdUser == id);

        public void InsertUser(UserPay user)
        {
            _context.UserPays.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public List<User> getAll()
        {
            return _context.Users.ToList(); ;
        }
    }
}