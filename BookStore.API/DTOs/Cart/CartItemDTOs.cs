using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Cart
{
    public class CartItemDTOs
    {
        [Required]
        public int IdProduct {get; set;}
        [Required]
        public int IdCart {get; set;}
        [Required]
        public int Quantity {get; set;}
        
    }
}