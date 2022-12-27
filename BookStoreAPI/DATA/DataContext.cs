using BookStoreAPI.DATA.Enities.Auth;
using BookStoreAPI.DATA.Enities.Cart;
using BookStoreAPI.DATA.Enities.Order;
using BookStoreAPI.DATA.Enities.Product;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<UserPay> UserPays {get; set;}
        public DbSet<Products> Products {get; set;}
        public DbSet<ProductCate> Categories {get; set;}
        public DbSet<ProductFeed> ProductFeeds {get; set;}
        public DbSet<CartItem> CartItems {get; set;}
        public DbSet<Carts> Carts {get; set;}
        public DbSet<MethodPay> MethodPays {get; set;}
        public DbSet<OrderProduct> OrderProducts {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<Payment> Payments {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
            .HasMany(p => p.users)
            .WithOne(c => c.roles)
            .HasForeignKey(p => p.RoleId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasOne(p => p.productFeeds)
            .WithOne(c => c.users)
            .HasForeignKey<ProductFeed>(p => p.UserID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPay>()
            .HasOne(p => p.users)
            .WithMany(c => c.UserPays)
            .HasForeignKey(p => p.UserId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCate>()
            .HasMany(t => t.products)
            .WithOne(p => p.productCates)
            .HasForeignKey(p => p.IdCate);
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductFeed>()
            .HasOne(p => p.products)
            .WithMany(c => c.productFeeds)
            .HasForeignKey(p => p.ProductID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
            .HasOne(p => p.methodPays)
            .WithMany(c => c.payments)
            .HasForeignKey(p => p.TypePay);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
            .HasOne(p => p.orders)
            .WithOne(c => c.payments)
            .HasForeignKey<Payment>(c => c.IdOrder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Orders>()
            .HasOne(p => p.users)
            .WithMany(c => c.orders)
            .HasForeignKey(c => c.IdUser);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
            .HasOne(p => p.orders)
            .WithMany(c => c.orderProducts)
            .HasForeignKey(c => c.IdOrder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
            .HasOne(p => p.products)
            .WithMany(c => c.orderProducts)
            .HasForeignKey(c=>c.IdProduct);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>()
            .HasOne(p => p.carts)
            .WithMany(c => c.cartItems)
            .HasForeignKey(c => c.IdCart);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>()
            .HasMany(p => p.cartItems)
            .WithOne(c => c.products)
            .HasForeignKey(c => c.IdProduct);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carts>()
            .HasOne(p => p.users)
            .WithOne(c => c.carts)
            .HasForeignKey<Carts>(c => c.IdUser);
            base.OnModelCreating(modelBuilder);
        }
    }
}