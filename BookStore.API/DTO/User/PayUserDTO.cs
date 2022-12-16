using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.User
{
    public class PayUserDTO
    {
        [Required]
        public int UserId {get; set;}
        [Required]
        [MaxLength(256)]
        public string PayType {get; set;}
        
    }
}