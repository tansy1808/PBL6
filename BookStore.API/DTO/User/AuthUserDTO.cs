using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.User
{
    public class AuthUserDTO
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