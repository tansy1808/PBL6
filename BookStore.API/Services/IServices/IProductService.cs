using BookStore.API.Data.Enities.Product;

namespace BookStore.API.Services.IServices
{
    public interface IProductService
    {
        void InsertProduct(Products products);
        void InsertProductFeed(ProductFeed productFeed);
        void InsertCategory(ProductCate productCate);
        void UpdateProduct(Products products);
        void DeteleProduct(Products products);
        void DeteleFeed(List<ProductFeed> feed);
        List<Products> GetProductsbyName(string productName);
        Products GetProductsById(int id);
        List<Products> GetProductsByCategory(int categoryId);
        List<Products> GetProducts();
        List<ProductCate> GetProductCate();
        List<ProductFeed> GetProductFeedById(int id);
        bool IsSaveChanges();
    }
}