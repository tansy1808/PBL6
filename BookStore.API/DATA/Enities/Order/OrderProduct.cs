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
        public int IdProduct {get; set;}
        public int Quantity {get; set;}
        public decimal Price {get; set;}
        public Products products {get; set;}
        public Orders orders {get; set;}
    }
}