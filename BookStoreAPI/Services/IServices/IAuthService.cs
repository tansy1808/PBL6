using BookStoreAPI.DTO;
using BookStoreAPI.DTO.User;

namespace BookStoreAPI.Services.IServices
{
    public interface IAuthService
    {
        ViewBag Login(AuthUserLogin authUserLogin);
        ViewBag Register(AuthUserDTO authUserDto);
        ViewBag Change(int id, ChangePass changePass);
        ViewBag ChangePass(string email, string newpass, string repass);
        MemberAPI GetUserAll(int page, int size);
        UserDTO GetUserByUserName(string name);
        UserDTO GetUserById(int id);
        ViewBag UpdateUser(int id, AuthUpdateDTO authUpdateDTO);
        ViewBag UpdateImage(int id, UserImage userImage);
        ViewBag CreatePay(PayUserDTO payUserDto);
    }
}