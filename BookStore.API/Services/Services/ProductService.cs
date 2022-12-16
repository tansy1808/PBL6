using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.Services.IServices;
using BookStore.API.DTOs.Views;

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

        public ProductCate GetCateById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public List<ProductCate> GetProductCate()
        {
            return _context.Categories.ToList();
        }

        public List<ProductFeed> GetProductFeedById(int id)
        {
            return _context.ProductFeeds.Where(c =>c.ProductID == id).ToList();
        }

        public List<Products> GetProductsAll()
        { 
            return _context.Products.ToList();
            
        }

        public ProductByCateDTOs GetProductsByCategory(int categoryId, int page, int size)
        {
            var query = _context.Products.Where(c => c.IdCate == categoryId);
            int total = query.Count();
            int pagecount = total / size;
            float Page = total % size;
            if (Page > 0) { pagecount = pagecount + 1; }
            var data = query.Skip(((page) - 1) * size).Take(size).ToList();
            List<ProductViewDTOs> list = new List<ProductViewDTOs>();
            var title = _context.Categories.FirstOrDefault(c => c.Id == categoryId).CategoryType;
            foreach (Products i in data)
            {
                var proview = new ProductViewDTOs
                {
                    IdProduct = i.IdProduct,
                    Name = i.Name,
                    Image = i.Image,
                    Desc = i.Desc,
                    Feedback = i.Feedback,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    DateCreate = i.DateCreate,
                    Discount = i.Discount,
                    Cate = title
                };
                list.Add(proview);
            }
            var product = new ProductPageDTOs
            {
                Size = size,
                Page = page,
                Total = pagecount,
                Views = list
            };
            var view = new ProductByCateDTOs
            {
                Title = title,
                Page = product
            };
            return view;

        }

        public Products GetProductsById(int id)
        {
            return _context.Products.FirstOrDefault(c => c.IdProduct == id);
        }

        public List<Products> GetProductsbyName(string productName)
        {
            return _context.Products.Where(c => c.Name.Contains(productName)).ToList();
        }

        public ProductPageDTOs GetProductsPage(int page, int size)
        {
            var query = _context.Products;
            int total = query.Count();
            int pagecount = total / size;
            float Page = total % size;
            if (Page > 0) { pagecount = pagecount + 1; }
            var data = query.Skip(((page) - 1) * size).Take(size).ToList();
            List<ProductViewDTOs> list = new List<ProductViewDTOs>();
            foreach (Products i in data)
            {
                var proview = new ProductViewDTOs
                {
                    IdProduct = i.IdProduct,
                    Name = i.Name,
                    Image = i.Image,
                    Desc = i.Desc,
                    Feedback = i.Feedback,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    DateCreate = i.DateCreate,
                    Discount = i.Discount,
                    Cate = _context.Categories.FirstOrDefault(c => c.Id == i.IdCate).CategoryType
                };
                list.Add(proview);
            }
            var view = new ProductPageDTOs
            {
                Size = size,
                Page = page,
                Total = pagecount,
                Views = list
            };
            return view;
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