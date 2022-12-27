using BookStoreAPI.DATA.Enities.Product;
using BookStoreAPI.DATA.Reponsitories.IR;

namespace BookStoreAPI.DATA.Reponsitories.Repon
{
    public class ProductReponsitory : IProductReponsitory
    {
        private readonly DataContext _context;

        public ProductReponsitory(DataContext context)
        {
            _context = context;
        }

        public void DeleteCategory(ProductCate productCate)
        {
            _context.Categories.Remove(productCate);
        }

        public void DeteleFeed(ProductFeed feed)
        {
            _context.ProductFeeds.Remove(feed);
        }

        public void DeteleProduct(Products products)
        {
            _context.Products.Remove(products);
        }

        public ProductCate GetCateById(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);

        public List<ProductCate> GetProductCate()
        {
            return _context.Categories.ToList();
        }

        public List<ProductFeed> GetProductFeedById(int id)
        {
            return _context.ProductFeeds.Where(c => c.ProductID == id).ToList();
        }

        public List<Products> GetProductsAll()
        {
            return _context.Products.ToList();
        }

        public List<Products> GetProductsById(int id)
        {
            return _context.Products.Where(c => c.IdCate == id).ToList();
        }

        public Products GetProductsByIdpro(int id)
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

        public void UpdateCategory(ProductCate productCate)
        {
            _context.Categories.Update(productCate);
        }

        public void UpdateProduct(Products products)
        {
            _context.Products.Update(products);
        }
    }
}
