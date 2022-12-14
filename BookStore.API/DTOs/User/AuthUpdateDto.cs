using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.User
{
    public class AuthUpdateDto
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Address { get; set; }
        [Required]
        [MaxLength(15)]
        public string Contact { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
    }
}
