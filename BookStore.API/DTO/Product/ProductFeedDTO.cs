using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Product
{
    public class ProductFeedDTO
    {
        public string Comment {get; set;}
        [Required]
        public int star {get; set;}
        [Required]
        public int ProductID {get; set;}
        [Required]
        public int UserID {get; set;}
    }
}