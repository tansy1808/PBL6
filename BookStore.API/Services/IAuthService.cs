

using BookStore.API.Data.Enities.Auth;

namespace BookStore.API.Services
{
    public interface IAuthService
    {
        Task<User> UpdateEmployee(User employee);
    }
}