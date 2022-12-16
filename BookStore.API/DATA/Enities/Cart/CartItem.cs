using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Product;

namespace BookStore.API.Data.Enities.Cart
{
    public class CartItem
    {
        [Key]
        public int Id {get; set;}
        public int IdProduct {get; set;}
        public int IdCart {get; set;}
        public int Quantity {get; set;}
        public Carts carts {get; set;}
        public Products products {get; set;}
    }
}