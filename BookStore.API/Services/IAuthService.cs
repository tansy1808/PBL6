using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTO;
using BookStore.API.DTO.User;

namespace BookStore.API.Services
{
    public interface IAuthService
    {
        public ViewBag Login(AuthUserLogin authUserLogin);
        public ViewBag Register(AuthUserDTO authUserDto);
        public ViewBag Change(int id,ChangePass changePass);
        MemberAPI GetUserAll();
        UserDTO GetUserByUserName(string name);
        UserDTO GetUserById(int id);
        User UpdateUser(int id, AuthUpdateDTO authUpdateDTO);
        User UpdateImage(int id, UserImage userImage);
        UserPay CreatePay(PayUserDTO payUserDto);
    }
}