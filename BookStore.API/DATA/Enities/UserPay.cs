
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities
{
    public class UserPay
    {
        [Key]
        public int PayID {get; set;}
        [MaxLength(256)]
        public string PayType {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        
    }
}