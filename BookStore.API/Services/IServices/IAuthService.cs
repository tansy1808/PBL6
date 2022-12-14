using BookStore.API.Data.Enities.Auth;
using BookStore.API.DTOs.User;

namespace BookStore.API.Services.IServices
{
    public interface IAuthService
    {
        public string Login(AuthUserLogin authUserLogin);
        public string Register(AuthUserDto authUserDto);
        User getUserId(int id);
        void InsertUser(UserPay user);
        void UpdateUser(User user);
        bool IsSaveChanges();
    }
}