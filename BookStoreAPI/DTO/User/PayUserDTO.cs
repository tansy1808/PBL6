using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTO.User
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