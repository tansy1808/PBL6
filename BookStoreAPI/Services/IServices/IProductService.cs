using BookStoreAPI.DATA.Enities.Product;
using BookStoreAPI.DTO;
using BookStoreAPI.DTO.Product;

namespace BookStoreAPI.Services.IServices
{
    public interface IProductService
    {
        ViewProductDTO AddProduct(ProductDTO productDTOs);
        ViewProductFeedDTO AddProductFeed(ProductFeedDTO productFeedDTOs);
        ViewCategory AddCategory(CategoryDTO categoryDTO);
        ViewCategory UpdateCategory(int id, CategoryDTO categoryDTO);
        ViewProductDTO UpdateProduct(int id, ProductDTO productDTOs);
        List<ProductView> GetProductByDate(int sl);
        CategoryAPI GetProductByPrice(int categoryId, int st, int end, int page, int size);
        CategoryAPI GetProductNameByPrice(string name, int st, int end, int page, int size);
        ProductAPI GetProductsByName(string name, int page, int size);
        ProductPage GetProductAll(int page, int size);
        CategoryAPI GetProductsByCategory(int categoryId, int page, int size);
        List<FeedDTO> GetProductFeedById(int id);
        List<ProductCate> GetProductCate();
        ProductView GetProductById(int id);
        ViewProductDTO Delete(int id);
        ViewCategory DeleteCate(int id);
    }
}