using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Auth;

namespace BookStore.API.Data.Enities.Order
{
    public class Orders
    {
        [Key]
        public int IdOrder {get; set;}
        [Required]
        public int IdUser {get; set;}
        [Required]
        public string Address {get; set;}
        [Required]
        [MaxLength(256)]
        public string Status { get; set; }
        [Required]
        public int Total {get; set;}
        [Required]
        public DateTime DateOrder {get; set;}
        public List<OrderProduct> orderProducts {get; set;}
        public User users {get; set;}
        public Payment payments {get; set;}
    }
}