using BookStore.API.Data.Enities.Product;
using BookStore.API.DTO;
using BookStore.API.DTO.Product;

namespace BookStore.API.Services
{
    public interface IProductService
    {
        List<ProductView> GetProductByDate( int sl);
        ProductPage GetProductByCate(int categoryId, int page, int size);
        ProductPage GetProductByPrice(int categoryId,int st, int end, int page, int size);
        ViewProductDTO CreateProduct(ProductDTO productDTOs);
        ViewProductFeedDTO AddProductFeed(ProductFeedDTO productFeedDTOs);
        ProductAPI GetProductsByName(string name, int page, int size);
        ProductPage GetProductAll(int page,int size);
        CategoryAPI GetProductsByCategory(int categoryId, int page, int size);
        List<FeedDTO> GetProductFeedById(int id);
        List<ProductCate> GetProductCate();
        ProductView GetProductById(int id);
        ViewProductDTO UpdateProduct(int id, ProductDTO productDTOs);
        Products Delete(int id);
    }
}