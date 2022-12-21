using BookStore.API.Data.Enities.Auth;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO;
using BookStore.API.DTO.User;
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
        public ViewBag Login(AuthUserLogin authUserLogin)
        {
            authUserLogin.Username = authUserLogin.Username.ToLower();
            var currentUser = _userReponsitory.GetUserByUsername(authUserLogin.Username);
            if (currentUser == null)
            {
                var view1 = new ViewBag()
                {
                    Status = "Error",
                    Message = "Sai Password hoặc Username.",
                    Title = null,
                    data = null
                };
                return view1;
            }
            var user = new UserDTO
            {
                IdUser = currentUser.IdUser,
                Username = currentUser.Username,
                UserImage = currentUser.UserImage,
                Name= currentUser.Name,
                Address= currentUser.Address,
                Contact= currentUser.Contact,
                Email= currentUser.Email,
                Role = _userReponsitory.GetRoleById(currentUser.RoleId).RoleName,
            };
            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(authUserLogin.Password)
            );
            for (int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if (currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    var view2 = new ViewBag()
                    {
                        Status = "Error",
                        Message = "Sai Password hoặc Username.",
                        Title = null,
                        data = null
                    };
                    return view2;
                }
            }
            var view = new ViewBag()
            {
                Status = "Success",
                Message = "Thành công",
                Title = _tokenService.CreateToken(currentUser.Username),
                data = user
            };
            return view;
        }

        public ViewBag Change(int id, ChangePass changePass)
        {
            var pass = _userReponsitory.GetUserById(id);
            using var hmac = new HMACSHA512(pass.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(changePass.Password));
            for (int i = 0; i < pass.PasswordHash.Length; i++)
            {
                if (pass.PasswordHash[i] != passwordBytes[i])
                {
                    var view1 = new ViewBag()
                    {
                        Status = "Error",
                        Message = "Sai mật khẩu",
                        Title = null,
                        data = null
                    };
                    return view1;
                }
                if (changePass.NewPassword == changePass.RePassword)
                {
                    var password = Encoding.UTF8.GetBytes(changePass.Password);
                    pass.PasswordHash = hmac.ComputeHash(passwordBytes);
                    pass.PasswordSalt = hmac.Key;
                    _userReponsitory.UpdateUser(pass);
                    _userReponsitory.IsSaveChanges();
                    var view3 = new ViewBag()
                    {
                        Status = "Success",
                        Message = "Thành công",
                        Title = _tokenService.CreateToken(pass.Username),
                        data = null
                    };
                    return view3;
                }
                else
                {
                    var view2 = new ViewBag()
                    {
                        Status = "Error",
                        Message = "Mật khẩu mới không giống nhau",
                        Title = null,
                        data = null
                    };
                    return view2;
                }
            }
            var view = new ViewBag()
            {
                Status = "Success",
                Message = "Thành công",
                Title = _tokenService.CreateToken(pass.Username),
                data = null,
            };
            return view;
        }

        public ViewBag Register(AuthUserDTO authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if (_userReponsitory.GetUserAnyUsername(authUserDto.Username))
            {
                var view2 = new ViewBag()
                {
                    Status = "Error",
                    Message = "Username đã tồn tại.!",
                    Title = null,
                    data = null
                };
                return view2;
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

            var view = new ViewBag()
            {
                Status = "Success",
                Message = "Thành công",
                Title = _tokenService.CreateToken(user.Username),
                data = null
            };
            return view;
        }

        public MemberAPI GetUserAll()
        {
            var users = _userReponsitory.GetUsers();
            List<UserDTO> result = new List<UserDTO> { };
            if(users != null)
            {
                foreach (User i in users)
                {
                    var add = new UserDTO
                    {
                        IdUser = i.IdUser,
                        Username = i.Username,
                        UserImage = i.UserImage,
                        Address = i.Address,
                        Name = i.Name,
                        Email = i.Email,
                        Role = _userReponsitory.GetRoleById(i.RoleId).RoleName,
                        Contact = i.Contact
                    };
                    result.Add(add);
                };
            }
            MemberAPI rs = new MemberAPI
            {
                data = result
            };
            return rs;
        }

        public UserDTO GetUserByUserName(string name)
        {
            var user = _userReponsitory.GetUserByUsername(name);
            var add = new UserDTO();
            if (user != null) 
            {
                add.IdUser = user.IdUser;
                add.Username = user.Username;
                add.UserImage = user.UserImage;
                add.Address = user.Address;
                add.Name = user.Name;
                add.Email = user.Email;
                add.Role = _userReponsitory.GetRoleById(user.RoleId).RoleName;
                add.Contact = user.Contact;
            }
            return add;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userReponsitory.GetUserById(id);
            var add = new UserDTO();
            if (user != null)
            {
                add.IdUser = user.IdUser;
                add.Username = user.Username;
                add.UserImage = user.UserImage;
                add.Address = user.Address;
                add.Name = user.Name;
                add.Email = user.Email;
                add.Role = _userReponsitory.GetRoleById(user.RoleId).RoleName;
                add.Contact = user.Contact;
            }
            return add;
        }

        public ViewBag UpdateUser(int id, AuthUpdateDTO authUpdateDTO)
        {
            var user = _userReponsitory.GetUserById(id);
            var view = new ViewBag()
            {
                Status = "Error",
                Message = "Không tìm thấy User.",
                Title = null,
                data = null
            };
            if (user != null)
            {
                user.Name = authUpdateDTO.Name;
                user.Address = authUpdateDTO.Address;
                user.Contact = authUpdateDTO.Contact;
                user.Email = authUpdateDTO.Email;
                _userReponsitory.UpdateUser(user);
                _userReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.Title = null;
                view.data = null;
            };
            return view;
        }

        public ViewBag UpdateImage(int id, UserImage userImage)
        {
            var user = _userReponsitory.GetUserById(id);
            var view = new ViewBag()
            {
                Status = "Error",
                Message = "Không tìm thấy User.",
                Title = null,
                data = null
            };
            if (user != null) {
                user.UserImage = userImage.Userimage;
                _userReponsitory.UpdateUser(user);
                _userReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.Title = null;
                view.data = null;
            }
            return view;
        }

        public ViewBag CreatePay(PayUserDTO payUserDto)
        {
            var user = _userReponsitory.GetUserById(payUserDto.UserId);
            var view = new ViewBag()
            {
                Status = "Error",
                Message = "Không tìm thấy User.",
                Title = null,
                data = null
            };
            var userpay = new UserPay();
            if (user != null)
            {
                userpay.UserId = payUserDto.UserId;
                userpay.PayType = payUserDto.PayType;
                _userReponsitory.InsertPay(userpay);
                _userReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.Title = null;
                view.data = null;
            }
            return view;
        }
    }
}