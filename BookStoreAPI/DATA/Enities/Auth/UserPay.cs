using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DATA.Enities.Auth
{
    public class UserPay
    {
        [Key]
        public int PayID {get; set;}
        [MaxLength(256)]
        public string? PayType {get; set;}
        [Required]
        public int UserId {get; set;}
        public User users {get; set;}
        
    }
}