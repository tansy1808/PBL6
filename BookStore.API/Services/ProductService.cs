using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO;
using BookStore.API.DTO.Product;
using BookStore.API.DTO.User;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IProductReponsitory _productReponsitory;

        public ProductService(DataContext context, IProductReponsitory productReponsitory)
        {
            _context = context;
            _productReponsitory = productReponsitory;
        }

        public ProductFeed AddProductFeed( ProductFeedDTO productFeedDTOs)
        {
            var user = _context.Users.FirstOrDefault(c=>c.IdUser==productFeedDTOs.UserID);
            var feed = new ProductFeed();
            if (user != null) 
            {
                var pro = _productReponsitory.GetProductsByIdpro(productFeedDTOs.ProductID);
                if (pro != null)
                {
                    feed.Star = productFeedDTOs.star;
                    feed.Comment = productFeedDTOs.Comment;
                    feed.ProductID = productFeedDTOs.ProductID;
                    feed.UserID = productFeedDTOs.UserID;
                    feed.FeedDate = DateTime.Now;
                    _productReponsitory.InsertProductFeed(feed);
                    _productReponsitory.IsSaveChanges();
                }
            }
            return feed;  
        }

        public Products CreateProduct(ProductDTO productDTO)
        {
            var pro = _context.Categories.FirstOrDefault(c => c.Id == productDTO.IdCate);
            var products = new Products();
            if (pro != null)
            {
                products.Name = productDTO.Name;
                products.Desc = productDTO.Desc;
                products.Image = productDTO.Image;
                products.Price = productDTO.Price;
                products.Quantity = productDTO.Quantity;
                products.DateCreate = DateTime.Now;
                products.Discount = productDTO.Discount;
                products.IdCate = productDTO.IdCate;
                _productReponsitory.InsertProduct(products);
                _productReponsitory.IsSaveChanges();
            }
            return products;
        }

        public Products Delete(int id)
        {
            var product = _productReponsitory.GetProductsByIdpro(id);
            if (product != null)
            {
                var feed = _productReponsitory.GetProductFeedById(id);
                if (feed != null)
                {
                    foreach (ProductFeed i in feed)
                    {
                        _productReponsitory.DeteleFeed(i);
                    }
                }                
                _productReponsitory.DeteleProduct(product);
                _productReponsitory.IsSaveChanges();
            }
            return product;
            
        }

        public ProductPage GetProductAll(int page, int size)
        {
            var query = _context.Products;
            int total = query.Count();
            int pagecount = total / size;
            float Page = total % size;
            if (Page > 0) { pagecount = pagecount + 1; }
            var data = query.Skip(((page) - 1) * size).Take(size).ToList();
            List<ProductView> list = new List<ProductView>();
            foreach (Products i in data)
            {
                var proview = new ProductView
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
            var view = new ProductPage
            {
                Size = size,
                Page = page,
                TotalPage = pagecount,
                data = list
            };
            return view;
        }

        public ProductView GetProductById(int id)
        {
            var product = _productReponsitory.GetProductsByIdpro(id);
            var view = new ProductView();
            if (product != null) 
            {
                view.Name = product.Name;
                view.IdProduct= product.IdProduct;
                view.Image = product.Image;
                view.Desc = product.Desc;
                view.Feedback = product.Feedback;
                view.Price = product.Price;
                view.Quantity = product.Quantity;
                view.DateCreate = product.DateCreate;
                view.Discount = product.Discount;
                view.Cate = _context.Categories.FirstOrDefault(c => c.Id == product.IdCate).CategoryType;
            }
            return view;
        }

        public ProductAPI GetProductByName(string name)
        {
            var pro = _productReponsitory.GetProductsbyName(name);
            List<ProductView> list = new List<ProductView> { };
            if(pro != null)
            {
                foreach (Products i in pro)
                {
                    var add = new ProductView
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
                        Cate = _productReponsitory.GetCateById(i.IdCate).CategoryType
                    };
                    list.Add(add);
                };
            }
            ProductAPI rs = new ProductAPI
            {
                keyword = name,
                data = list
            };
            return rs;
        }

        public List<ProductCate> GetProductCate()
        {
            return _productReponsitory.GetProductCate();
        }

        public List<FeedDTO> GetProductFeedById(int id)
        {
            var feed = _productReponsitory.GetProductFeedById(id);
            List<FeedDTO> list = new List<FeedDTO> { };
            if(feed != null)
            {
                foreach (ProductFeed i in feed)
                {
                    FeedDTO rs = new FeedDTO
                    {
                        Comment = i.Comment,
                        star = i.Star,
                        ProductID = i.ProductID,
                        FeedDate = i.FeedDate,
                        Name = _context.Users.FirstOrDefault(c => c.IdUser == i.UserID).Name
                    };
                    list.Add(rs);
                };
            }           
            return list;
        }

        public CategoryAPI GetProductsByCategory(int categoryId, int page, int size)
        {
            var query = _context.Products.Where(c => c.IdCate == categoryId);
            int total = query.Count();
            int pagecount = total / size;
            float Page = total % size;
            if (Page > 0) { pagecount = pagecount + 1; }
            var data = query.Skip(((page) - 1) * size).Take(size).ToList();
            List<ProductView> list = new List<ProductView>();
            var title = _productReponsitory.GetCateById(categoryId).CategoryType;
            foreach (Products i in data)
            {
                var proview = new ProductView
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
            var product = new ProductPage
            {
                Size = size,
                Page = page,
                TotalPage = pagecount,
                data = list
            };
            var view = new CategoryAPI
            {
                Title = title,
                data = product
            };
            return view;
        }
        public Products UpdateProduct(int id, ProductDTO productDTOs)
        {
            var product = _productReponsitory.GetProductsByIdpro(id);
            if (product != null)
            {
                product.Name = productDTOs.Name;
                product.Image = productDTOs.Image;
                product.Desc = productDTOs.Desc;
                product.Price = productDTOs.Price;
                product.Quantity = productDTOs.Quantity;
                product.Discount = productDTOs.Discount;
                product.IdCate = productDTOs.IdCate;
                _productReponsitory.UpdateProduct(product);
                _productReponsitory.IsSaveChanges();
            }
            return product;
        }
    }
}