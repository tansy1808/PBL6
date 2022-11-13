using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Product;

namespace BookStore.API.Data.Enities.Order
{
    public class OrderProduct
    {
        [Key]
        public int IdOrderProduct {get; set;}
        [Required]
        public int IdOrder {get; set;}
        [Required]
        public int IdProduct {get; set;}
        [Required]
        public int Quantity {get; set;}
        [Required]
        public decimal Price {get; set;}
        public Products products {get; set;}
        public Orders orders {get; set;}
    }
}