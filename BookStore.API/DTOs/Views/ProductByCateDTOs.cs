using BookStore.API.Data.Enities.Product;

namespace BookStore.API.DTOs.Views
{
    public class ProductByCateDTOs : Products
    {
        public string Title { get; set; }
        public ProductPageDTOs Page { get; set; }

    }
}
