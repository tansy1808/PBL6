using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Store
{
    public class OrderProductDTOs
    {
        [Required]
        public int IdOrder {get; set;}
        [Required]
        public int IdProduct {get; set;}
        [Required]
        public int Quantity {get; set;}
        [Required]
        public decimal Price {get; set;}
    }
}