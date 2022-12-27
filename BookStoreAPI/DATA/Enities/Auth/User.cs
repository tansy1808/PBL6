using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DATA.Enities.Cart;
using BookStoreAPI.DATA.Enities.Order;
using BookStoreAPI.DATA.Enities.Product;

namespace BookStoreAPI.DATA.Enities.Auth
{
    public class User
    {
        [Key]
        public int IdUser {get; set;}
        [Required]
        [MaxLength(256)]
        public string Username {get; set;}
        [Required]
        [MaxLength(256)]
        public byte[] PasswordHash {get; set;}
        [Required]
        [MaxLength(256)]
        public byte[] PasswordSalt {get; set;}
        public string? UserImage {get; set;}
        [Required]
        [MaxLength(256)]
        public string Name {get; set;}
        public string? Address {get; set;}
        [MaxLength(15)]
        public string? Contact {get; set;}
        [Required]
        [MaxLength(256)]
        public string Email {get; set;}
        [Required]
        public int RoleId {get; set;}
        public Role roles {get; set;}
        public Carts carts {get; set;}
        public ProductFeed productFeeds {get; set;}
        public List<UserPay> UserPays {get; set;}
        public List<Orders> orders {get; set;}
    }
}