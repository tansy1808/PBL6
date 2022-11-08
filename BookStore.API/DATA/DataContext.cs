using BookStore.API.Data.Enities.Auth;
using BookStore.API.Data.Enities.Product;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> SetUser {get; set;}
        public DbSet<Role> SetRole {get; set;}
        public DbSet<UserPay> SetPay {get; set;}
        public DbSet<Products> SetProduct {get; set;}
        public DbSet<ProductCate> SetCate {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(p => p.Role)
            .WithMany(c => c.Users)
            .HasForeignKey(p => p.RoleId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPay>()
            .HasOne(p => p.User)
            .WithMany(c => c.UserPays)
            .HasForeignKey(p => p.UserId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>()
            .HasOne(p => p.ProductCate)
            .WithMany(c => c.products)
            .HasForeignKey(p => p.IdCate);
            base.OnModelCreating(modelBuilder);
        }
    }
}