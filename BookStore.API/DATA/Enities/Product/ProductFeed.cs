using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Auth;

namespace BookStore.API.Data.Enities.Product
{
    public class ProductFeed
    {
        [Key]
        public int IdFeed {get; set;}
        [Required]
        [MaxLength(256)]
        public string Comment {get; set;}
        [Required]
        public int star {get; set;}
        [Required]
        public int ProductID {get; set;}
        [Required]
        public int UserID {get; set;}
        public Products products {get; set;}
        public User users {get; set;}
    }
}