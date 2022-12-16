using BookStore.API.DTO.Product;

namespace BookStore.API.DTO
{
    public class CategoryAPI
    {
        public string Title { get; set; }
        public ProductPage data { get; set; }
    }
}
