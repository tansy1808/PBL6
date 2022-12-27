using BookStoreAPI.DTO.Product;

namespace BookStoreAPI.DTO.Cart
{
    public class CartItemDTO
    {
        public int id { get; set; }
        public int QuantityCart {get; set;}
        public ProductView Product { get; set; }

    }
}