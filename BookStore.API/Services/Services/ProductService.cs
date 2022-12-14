using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.Services.IServices;
using System.Xml.Linq;

namespace BookStore.API.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void DeteleFeed(List<ProductFeed> feed)
        {
            foreach (ProductFeed i in feed)
            {
                _context.ProductFeeds.Remove(i);
            }
        }

        public void DeteleProduct(Products products)
        {
            _context.Products.Remove(products);
        }

        public List<ProductCate> GetProductCate()
        {
            return _context.Categories.ToList();
        }

        public List<ProductFeed> GetProductFeedById(int id)
        {
            return _context.ProductFeeds.Where(c =>c.ProductID == id).ToList();
        }

        public List<Products> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Products> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(c => c.IdCate == categoryId).ToList();
        }

        public Products GetProductsById(int id)
        {
            return _context.Products.FirstOrDefault(c => c.IdProduct == id);
        }

        public List<Products> GetProductsbyName(string productName)
        {
            return _context.Products.Where(c => c.Name.Contains(productName)).ToList();
        }

        public void InsertCategory(ProductCate productCate)
        {
            _context.Categories.Add(productCate);
        }

        public void InsertProduct(Products products)
        {
            _context.Products.Add(products);
        }

        public void InsertProductFeed(ProductFeed productFeed)
        {
            _context.ProductFeeds.Add(productFeed);
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateProduct(Products products)
        {
            _context.Products.Update(products);
        }
    }
}