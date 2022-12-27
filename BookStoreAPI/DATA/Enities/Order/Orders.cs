using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DATA.Enities.Auth;

namespace BookStoreAPI.DATA.Enities.Order
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
        public string SDT {get; set;}
        public string? Status { get; set; }
        public decimal Total {get; set;}
        [Required]
        public DateTime DateOrder {get; set;}
        public List<OrderProduct> orderProducts {get; set;}
        public User users {get; set;}
        public Payment payments {get; set;}
    }
}