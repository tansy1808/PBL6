using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DATA.Enities.Auth;

namespace BookStoreAPI.DATA.Enities.Product
{
    public class ProductFeed
    {
        [Key]
        public int IdFeed {get; set;}
        public string? Comment {get; set;}
        [Required]
        public int Star {get; set;}
        [Required]
        public DateTime FeedDate {get; set;}
        [Required]
        public int ProductID {get; set;}
        [Required]
        public int UserID {get; set;}
        public Products products {get; set;}
        public User users {get; set;}
    }
}