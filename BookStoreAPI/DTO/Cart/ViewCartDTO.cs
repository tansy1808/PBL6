using BookStoreAPI.DATA.Enities.Cart;

namespace BookStoreAPI.DTO.Cart
{
    public class ViewCartDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Carts data { get; set; }
    }
}
