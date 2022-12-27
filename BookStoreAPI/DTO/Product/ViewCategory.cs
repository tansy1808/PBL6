using BookStoreAPI.DATA.Enities.Product;

namespace BookStoreAPI.DTO.Product
{
    public class ViewCategory
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ProductCate data { get; set; }
    }
}