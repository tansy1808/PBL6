using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs
{
    public class PayUserDto
    {
        [Required]
        public int UserId {get; set;}
        [Required]
        [MaxLength(256)]
        public string PayType {get; set;}
        
    }
}