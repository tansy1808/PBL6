using BookStoreAPI.DATA.Enities.Product;

namespace BookStoreAPI.DATA.Reponsitories.IR
{
    public interface IProductReponsitory
    {
        void InsertProduct(Products products);
        void InsertProductFeed(ProductFeed productFeed);
        void InsertCategory(ProductCate productCate);
        void UpdateProduct(Products products);
        void UpdateCategory(ProductCate productCate);
        void DeteleProduct(Products products);
        void DeleteCategory(ProductCate productCate);
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
