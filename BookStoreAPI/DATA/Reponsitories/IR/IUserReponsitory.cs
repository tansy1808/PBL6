using BookStoreAPI.DATA.Enities.Auth;

namespace BookStoreAPI.DATA.Reponsitories.IR
{
    public interface IUserReponsitory
    {
        List<User> GetUsers();
        User GetUserById(int id);
        Role GetRoleById(int id);
        User GetUserByUsername(string username);
        bool GetUserAnyUsername(string username);
        User GetUserByEmail(string email);
        bool GetUserAnyEmail(string email);
        void InsertUser(User user);
        void InsertPay(UserPay user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool IsSaveChanges();
    }
}
