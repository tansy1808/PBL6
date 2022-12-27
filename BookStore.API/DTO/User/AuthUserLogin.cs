using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.User
{
    public class AuthUserLogin
    {
        [Required]
        [MaxLength(256)]
        public string Username {get; set;}
        [Required]
        [MaxLength(256)]
        public string Password {get; set;}
    }
}