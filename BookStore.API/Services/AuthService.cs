using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services
{
    public class AuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> UpdateEmployee(User user)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(e => e.IdUser == user.IdUser);

            if (result != null)
            {
                

                return result;
            }

            return null;
        }
    }
}