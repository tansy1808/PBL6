using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;

namespace BookStore.API.DATA.Reponsitories
{
    public class UserReponsitory : IUserReponsitory
    {
        private readonly DataContext _context;

        public UserReponsitory(DataContext context)
        {
            _context = context;
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(u => u.IdRole == id);
        }

        public bool GetUserAnyUsername(string username)
        {
            return _context.Users.Any(user => user.Username == username);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.IdUser == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(user => user.Username == username);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void InsertPay(UserPay user)
        {
            _context.UserPays.Add(user);
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateUser(User user)
        {
            
        }
    }
}
