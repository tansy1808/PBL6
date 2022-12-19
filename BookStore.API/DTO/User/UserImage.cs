using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.User
{
    public class UserImage
    {
        [Required]
        [MaxLength(256)]
        public string Userimage {get; set;}
    }
}