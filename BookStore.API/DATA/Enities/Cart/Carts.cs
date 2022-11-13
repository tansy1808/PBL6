using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Auth;

namespace BookStore.API.Data.Enities.Cart
{
    public class Carts
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public int IdUser {get; set;}
        public User users {get; set;}
        public List<CartItem> cartItems {get; set;}
    }
}