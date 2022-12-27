namespace BookStoreAPI.DTO.Cart
{
    public class ViewCartItemDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public CartViewDTO data { get; set; }
    }
}
