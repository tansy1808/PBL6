using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Store
{
    public class OrderProductDTO
    {
        [Required]
        public int IdOrder {get; set;}
        [Required]
        public int IdProduct {get; set;}
        [Required]
        public int Quantity {get; set;}
    }
}