using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Store
{
    public class OrderDTO
    {
        [Required]
        public int IdUser {get; set;}
        [Required]
        public string Address {get; set;}
        [Required]
        public string SDT {get; set;}
        
    }
}