using BookStore.API.DTO.Product;

namespace BookStore.API.DTO
{
    public class ProductAPI
    {
        public string keyword { get; set; }
        public ProductPage data { get; set; }
    }
}
