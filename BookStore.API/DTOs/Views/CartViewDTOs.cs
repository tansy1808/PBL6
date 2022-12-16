using BookStore.API.Data.Enities.Cart;

namespace BookStore.API.DTOs.Views
{
    public class CartViewDTOs
    {
        public int Id { get; set; }
        public List<CartItem> items { get; set; }
    }
}
