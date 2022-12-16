using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.User
{
    public class AuthUserDto
    {
        [Required]
        public string Username {get; set;}
        [Required]
        public string Password {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Email {get; set;}
    }
}