using BookStore.API.Data.Enities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> SetUser {get; set;}
        public DbSet<Role> SetRole {get; set;}
        public DbSet<UserPay> SetPay {get; set;}

    }
}