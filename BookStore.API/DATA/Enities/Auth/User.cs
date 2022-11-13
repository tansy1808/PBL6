using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Product;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.Data.Enities.Order;

namespace BookStore.API.Data.Enities.Auth
{
    public class User
    {
        [Key]
        public int IdUser {get; set;}
        [Required]
        [MaxLength(256)]
        public string Username {get; set;}
        [MaxLength(256)]
        public byte[] PasswordHash {get; set;}
        [MaxLength(256)]
        public byte[] PasswordSalt {get; set;}
        [MaxLength(256)]
        public string Name {get; set;}
        [MaxLength(256)]
        public string Address {get; set;}
        [MaxLength(15)]
        public string Contact {get; set;}
        public int RoleId {get; set;}
        public Role roles {get; set;}
        public Carts carts {get; set;}
        public ProductFeed productFeeds {get; set;}
        public List<UserPay> UserPays {get; set;}
        public List<Orders> orders {get; set;}
    }
}