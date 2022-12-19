using BookStore.API.Data.Enities.Cart;

namespace BookStore.API.DTO.Cart
{
    public class ViewCartDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Carts data { get; set; }
    }
}
