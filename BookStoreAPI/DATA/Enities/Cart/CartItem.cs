using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DATA.Enities.Product;

namespace BookStoreAPI.DATA.Enities.Cart
{
    public class CartItem
    {
        [Key]
        public int Id {get; set;}
        public int IdProduct {get; set;}
        [Required]
        public int IdCart {get; set;}
        public int Quantity {get; set;}
        public Carts carts {get; set;}
        public Products products {get; set;}
    }
}