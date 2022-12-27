using BookStoreAPI.DATA.Enities.Product;

namespace BookStoreAPI.DTO.Product
{
    public class ViewProductDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Products data { get; set; }
    }
}
