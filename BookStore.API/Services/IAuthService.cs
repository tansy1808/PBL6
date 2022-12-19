using BookStore.API.DTO;
using BookStore.API.DTO.User;

namespace BookStore.API.Services
{
    public interface IAuthService
    {
        ViewBag Login(AuthUserLogin authUserLogin);
        ViewBag Register(AuthUserDTO authUserDto);
        ViewBag Change(int id,ChangePass changePass);
        MemberAPI GetUserAll();
        UserDTO GetUserByUserName(string name);
        UserDTO GetUserById(int id);
        ViewBag UpdateUser(int id, AuthUpdateDTO authUpdateDTO);
        ViewBag UpdateImage(int id, UserImage userImage);
        ViewBag CreatePay(PayUserDTO payUserDto);
    }
}