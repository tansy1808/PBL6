using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.User
{
    public class AuthUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
