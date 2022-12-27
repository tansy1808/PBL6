using BookStore.API.Data.Enities.Auth;

namespace BookStore.API.DATA.Reponsitories
{
    public interface IUserReponsitory
    {
        List<User> GetUsers();
        User GetUserById(int id);
        Role GetRoleById(int id);
        User GetUserByUsername(string username);
        bool GetUserAnyUsername(string username);
        void InsertUser(User user);
        void InsertPay(UserPay user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool IsSaveChanges();
    }
}
