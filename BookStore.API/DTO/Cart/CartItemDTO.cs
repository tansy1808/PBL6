using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Cart
{
    public class CartItemDTO
    {
        public int id { get; set; }
        public int IdProduct {get; set;}
        public int IdCart {get; set;}
        public int Quantity {get; set;}
        
    }
}