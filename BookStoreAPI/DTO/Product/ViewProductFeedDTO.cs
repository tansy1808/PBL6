using BookStoreAPI.DATA.Enities.Product;

namespace BookStoreAPI.DTO.Product
{
    public class ViewProductFeedDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ProductFeed data { get; set; }
    }
}
