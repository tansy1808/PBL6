using BookStore.API.Data.Enities.Product;
using BookStore.API.DTO.Product;

namespace BookStore.API.DATA.Reponsitories
{
    public interface IProductReponsitory
    {
        void InsertProduct(Products products);
        void InsertProductFeed(ProductFeed productFeed);
        void InsertCategory(ProductCate productCate);
        void UpdateProduct(Products products);
        void DeteleProduct(Products products);
        void DeteleFeed(ProductFeed feed);
        List<Products> GetProductsbyName(string productName);
        List<Products> GetProductsById(int id);
        Products GetProductsByIdpro(int id);
        ProductCate GetCateById(int id);
        List<ProductFeed> GetProductFeedById(int id);
        List<Products> GetProductsAll();
        List<ProductCate> GetProductCate();
        bool IsSaveChanges();
    }
}
