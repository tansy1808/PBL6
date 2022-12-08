using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.User
{
    public class AuthUserDto
    {
        [Required]
        [MaxLength(256)]
        public string Username {get; set;}
        [Required]
        [MaxLength(256)]
        public string Password {get; set;}
        [Required]
        [MaxLength(256)]
        public string Name {get; set;}
        [Required]
        [MaxLength(256)]
        public string Address {get; set;}
        [Required]
        [MaxLength(15)]
        public string Contact {get; set;}
        [Required]
        [MaxLength(256)]
        public string Email {get; set;}
        [Required]
        public int RoleId {get; set;}
    }
}