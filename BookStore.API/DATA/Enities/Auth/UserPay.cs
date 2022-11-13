
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities.Auth
{
    public class UserPay
    {
        [Key]
        public int PayID {get; set;}
        [Required]
        [MaxLength(256)]
        public string PayType {get; set;}
        [Required]
        public int UserId {get; set;}
        public User users {get; set;}
        
    }
}