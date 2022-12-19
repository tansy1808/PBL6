using BookStore.API.Data.Enities.Product;

namespace BookStore.API.DTO.Product
{
    public class ViewProductFeedDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ProductFeed data { get; set; }
    }
}
