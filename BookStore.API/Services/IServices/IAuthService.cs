using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;

namespace BookStore.API.Services.IServices
{
    public interface IAuthService
    {
        public string Login(AuthUserLogin authUserLogin);
        public string Register(AuthUserDto authUserDto);
        public string Change(int id,ChangePass changePass);
        User getUserId(int id);
        List<User> getAll();
        void InsertUser(UserPay user);
        void UpdateUser(User user);
        bool IsSaveChanges();
    }
}