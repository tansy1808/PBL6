using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Cart
{
    public class CartItemDTO
    {
        [Required]
        public int IdProduct {get; set;}
        [Required]
        public int IdCart {get; set;}
        [Required]
        public int Quantity {get; set;}
        
    }
}