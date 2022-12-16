using API.DatingApp.API.DTO;
using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO.User;
using BookStore.API.Services;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserReponsitory _userReponsitory;

        public AuthService(ITokenService tokenService, IUserReponsitory userReponsitory)
        {
            _tokenService = tokenService;
            _userReponsitory = userReponsitory;
        }
        public string Login(AuthUserLogin authUserLogin)
        {
            authUserLogin.Username = authUserLogin.Username.ToLower();
            var currentUser = _userReponsitory.GetUserByUsername(authUserLogin.Username);
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
            var pass = _userReponsitory.GetUserById(id);
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
                    _userReponsitory.UpdateUser(pass);
                    _userReponsitory.IsSaveChanges();
                    return _tokenService.CreateToken(pass.Username);
                }
                else throw new UnauthorizedAccessException("Password is unlike.");
            }
            return _tokenService.CreateToken(pass.Username);
        }

        public string Register(AuthUserDTO authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_userReponsitory.GetUserAnyUsername(authUserDto.Username))
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
            _userReponsitory.InsertUser(user);
            _userReponsitory.IsSaveChanges();

            return _tokenService.CreateToken(user.Username);
        }

        public MemberAPI GetUserAll()
        {
            var users = _userReponsitory.GetUsers();
            List<UserDTO> result = new List<UserDTO> { };
            foreach(User i in users)
            {
                var add = new UserDTO
                {
                    IdUser = i.IdUser,
                    Username= i.Username,
                    UserImage= i.UserImage,
                    Address= i.Address,
                    Name = i.Name,
                    Email = i.Email,
                    Role = _userReponsitory.GetRoleById(i.RoleId).RoleName,
                    Contact = i.Contact
                };
                result.Add(add);
            };
            MemberAPI rs = new MemberAPI
            {
                data = result
            };
            return rs;
        }

        public UserDTO GetUserByUserName(string name)
        {
            var user = _userReponsitory.GetUserByUsername(name);
            if(user == null) { return null; }
            var add = new UserDTO
            {
                IdUser = user.IdUser,
                Username = user.Username,
                UserImage = user.UserImage,
                Address = user.Address,
                Name = user.Name,
                Email = user.Email,
                Role = _userReponsitory.GetRoleById(user.RoleId).RoleName,
                Contact = user.Contact
            };
            return add;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userReponsitory.GetUserById(id);
            if (user == null) { return null; }
            var add = new UserDTO
            {
                IdUser = user.IdUser,
                Username = user.Username,
                UserImage = user.UserImage,
                Address = user.Address,
                Name = user.Name,
                Email = user.Email,
                Role = _userReponsitory.GetRoleById(user.RoleId).RoleName,
                Contact = user.Contact
            };
            return add;
        }

        public User UpdateUser(int id, AuthUpdateDTO authUpdateDTO)
        {
            var user = _userReponsitory.GetUserById(id);
            if (user == null) return null;
            user.Name = authUpdateDTO.Name;
            user.Address = authUpdateDTO.Address;
            user.Contact = authUpdateDTO.Contact;
            user.Email = authUpdateDTO.Email;
            _userReponsitory.UpdateUser(user);
            _userReponsitory.IsSaveChanges();
            return user;
        }

        public User UpdateImage(int id, UserImage userImage)
        {
            var user = _userReponsitory.GetUserById(id);
            if (user == null) return null;
            user.UserImage = userImage.Userimage;
            _userReponsitory.UpdateUser(user);
            _userReponsitory.IsSaveChanges();
            return user;
        }

        public UserPay CreatePay(PayUserDTO payUserDto)
        {
            var userpay = new UserPay
            {
                UserId = payUserDto.UserId,
                PayType = payUserDto.PayType
            };
            _userReponsitory.InsertPay(userpay);
            _userReponsitory.IsSaveChanges();

            return userpay;
        }
    }
}