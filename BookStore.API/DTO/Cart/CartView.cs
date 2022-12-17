

using BookStore.API.DTO.Product;

namespace BookStore.API.DTO.Cart
{
    public class CartView
    {
        public int Id { get; set; }
        public List<ProductView> items { get; set; }
    }
}
