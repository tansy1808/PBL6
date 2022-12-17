
using BookStore.API.Data.Enities.Product;
using BookStore.API.DTO;
using BookStore.API.DTO.Product;

namespace BookStore.API.Services
{
    public interface IProductService
    {
        Products CreateProduct(ProductDTO productDTOs);
        ProductFeed AddProductFeed(ProductFeedDTO productFeedDTOs);
        ProductAPI GetProductByName(string name);
        ProductPage GetProductAll(int page,int size);
        CategoryAPI GetProductsByCategory(int categoryId, int page, int size);
        List<FeedDTO> GetProductFeedById(int id);
        List<ProductCate> GetProductCate();
        ProductView GetProductById(int id);
        Products UpdateProduct(int id, ProductDTO productDTOs);
        Products Delete(int id);
    }
}