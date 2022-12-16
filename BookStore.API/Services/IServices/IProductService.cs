using BookStore.API.Data.Enities.Product;
using BookStore.API.DTOs.Product;
using BookStore.API.DTOs.Views;

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
        ProductCate GetCateById(int id);
        ProductByCateDTOs GetProductsByCategory(int categoryId, int page, int size);
        List<Products> GetProductsAll();
        ProductPageDTOs GetProductsPage(int page, int size);
        List<ProductCate> GetProductCate();
        List<ProductFeed> GetProductFeedById(int id);
        bool IsSaveChanges();
    }
}