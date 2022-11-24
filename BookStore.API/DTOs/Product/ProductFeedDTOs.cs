using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Product
{
    public class ProductFeedDTOs
    {
        [Required]
        [MaxLength(256)]
        public string Comment {get; set;}
        [Required]
        public int star {get; set;}
        [Required]
        public int ProductID {get; set;}
        [Required]
        public int UserID {get; set;}
    }
}