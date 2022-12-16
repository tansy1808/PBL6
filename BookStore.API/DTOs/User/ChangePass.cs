using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.User
{
    public class ChangePass
    {
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
        [Required]
        [MaxLength(256)]
        public string NewPassword { get; set; }
        [Required]
        [MaxLength(256)]
        public string RePassword { get; set; }
    }
}
