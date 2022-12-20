
using BookStore.API.Data.Enities.Product;

namespace BookStore.API.DTO.Cart
{
    public class CartViewDTO
    {
        public int Id {get; set;}
        public int IdProduct {get; set;}
        public int IdCart {get; set;}
        public int QuantityCart {get; set;}
        public Products product {get; set;}
    }
}