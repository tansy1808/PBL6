using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Product
{
    public class ProductDTOs
    {
        [Required]
        [MaxLength(256)]
        public string Name {get; set;}
        [Required]
        [MaxLength(256)]
        public string Image {get; set;}
        [Required]
        [MaxLength(4096)]
        public string Desc {get; set;}
        [Required]
        public int feedback {get; set;}
        [Required]
        public decimal price {get; set;}
        [Required]
        public int Quantity {get; set;}
        [Required]
        public decimal discount {get; set;}
    }
}