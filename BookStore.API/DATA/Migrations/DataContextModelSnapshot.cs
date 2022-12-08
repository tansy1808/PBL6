﻿// <auto-generated />
using System;
using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varbinary(256)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varbinary(256)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserImage")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("IdUser");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.UserPay", b =>
                {
                    b.Property<int>("PayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PayID"), 1L, 1);

                    b.Property<string>("PayType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PayID");

                    b.HasIndex("UserId");

                    b.ToTable("UserPays");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Cart.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCart")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCart");

                    b.HasIndex("IdProduct")
                        .IsUnique();

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Cart.Carts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.MethodPay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("MethodPays");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.OrderProduct", b =>
                {
                    b.Property<int>("IdOrderProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrderProduct"), 1L, 1);

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdOrderProduct");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.Orders", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrder"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IdOrder");

                    b.HasIndex("IdUser");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.Payment", b =>
                {
                    b.Property<int>("IdPay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPay"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("TypePay")
                        .HasColumnType("int");

                    b.HasKey("IdPay");

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.HasIndex("TypePay");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.ProductCate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.ProductFeed", b =>
                {
                    b.Property<int>("IdFeed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFeed"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("FeedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("IdFeed");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("ProductFeeds");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.Products", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"), 1L, 1);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Feedback")
                        .HasColumnType("int");

                    b.Property<decimal>("Frice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdCate")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdCate");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.User", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Auth.Role", "roles")
                        .WithOne("users")
                        .HasForeignKey("BookStore.API.Data.Enities.Auth.User", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.UserPay", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Auth.User", "users")
                        .WithMany("UserPays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Cart.CartItem", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Cart.Carts", "carts")
                        .WithMany("cartItems")
                        .HasForeignKey("IdCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.API.Data.Enities.Product.Products", "products")
                        .WithOne("cartItems")
                        .HasForeignKey("BookStore.API.Data.Enities.Cart.CartItem", "IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carts");

                    b.Navigation("products");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Cart.Carts", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Auth.User", "users")
                        .WithOne("carts")
                        .HasForeignKey("BookStore.API.Data.Enities.Cart.Carts", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.OrderProduct", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Order.Orders", "orders")
                        .WithMany("orderProducts")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.API.Data.Enities.Product.Products", "products")
                        .WithMany("orderProducts")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("orders");

                    b.Navigation("products");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.Orders", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Auth.User", "users")
                        .WithMany("orders")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.Payment", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Order.Orders", "orders")
                        .WithOne("payments")
                        .HasForeignKey("BookStore.API.Data.Enities.Order.Payment", "IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.API.Data.Enities.Order.MethodPay", "methodPays")
                        .WithMany("payments")
                        .HasForeignKey("TypePay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("methodPays");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.ProductFeed", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Product.Products", "products")
                        .WithMany("productFeeds")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.API.Data.Enities.Auth.User", "users")
                        .WithOne("productFeeds")
                        .HasForeignKey("BookStore.API.Data.Enities.Product.ProductFeed", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("products");

                    b.Navigation("users");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.Products", b =>
                {
                    b.HasOne("BookStore.API.Data.Enities.Product.ProductCate", "productCates")
                        .WithMany("products")
                        .HasForeignKey("IdCate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productCates");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.Role", b =>
                {
                    b.Navigation("users")
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Auth.User", b =>
                {
                    b.Navigation("UserPays");

                    b.Navigation("carts")
                        .IsRequired();

                    b.Navigation("orders");

                    b.Navigation("productFeeds")
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Cart.Carts", b =>
                {
                    b.Navigation("cartItems");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.MethodPay", b =>
                {
                    b.Navigation("payments");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Order.Orders", b =>
                {
                    b.Navigation("orderProducts");

                    b.Navigation("payments")
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.ProductCate", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("BookStore.API.Data.Enities.Product.Products", b =>
                {
                    b.Navigation("cartItems")
                        .IsRequired();

                    b.Navigation("orderProducts");

                    b.Navigation("productFeeds");
                });
#pragma warning restore 612, 618
        }
    }
}
