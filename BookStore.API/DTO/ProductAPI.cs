using BookStore.API.DTO.Product;

namespace BookStore.API.DTO
{
    public class ProductAPI
    {
        public string keyword { get; set; }
        public List<ProductView> data { get; set; }
    }
}
