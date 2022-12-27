using BookStore.API.Data.Enities.Cart;

namespace BookStore.API.DTO.Cart
{
    public class ViewCartItemDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public CartViewDTO data { get; set; }
    }
}
