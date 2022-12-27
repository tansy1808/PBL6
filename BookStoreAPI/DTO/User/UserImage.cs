using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTO.User
{
    public class UserImage
    {
        [Required]
        [MaxLength(256)]
        public string Userimage {get; set;}
    }
}