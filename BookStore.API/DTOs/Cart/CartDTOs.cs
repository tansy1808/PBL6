using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Cart
{
    public class CartDTOs
    {
        [Required]
        public int IdUser {get; set;}
    }
}