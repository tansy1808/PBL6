using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Store
{
    public class OrderDTOs
    {
        [Required]
        public int IdUser {get; set;}
        [Required]
        public string Address {get; set;}
        [Required]
        public int Total {get; set;}
    }
}