using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO;
using BookStore.API.DTO.Product;

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

        public ViewProductFeedDTO AddProductFeed( ProductFeedDTO productFeedDTOs)
        {
            var user = _context.Users.FirstOrDefault(c=>c.IdUser==productFeedDTOs.UserID);
            var feed = new ProductFeed();
            var view = new ViewProductFeedDTO()
            {
                Status = "Error",
                Message = "User không tồn tại",
                data = null
            };
            
            if (user != null) 
            {
                feed.Star = productFeedDTOs.star;
                feed.Comment = productFeedDTOs.Comment;
                feed.ProductID = productFeedDTOs.ProductID;
                feed.UserID = productFeedDTOs.UserID;
                feed.FeedDate = DateTime.Now;
                _productReponsitory.InsertProductFeed(feed);
                var pro = _productReponsitory.GetProductsByIdpro(productFeedDTOs.ProductID);
                view.Status = "Error";
                view.Message = "Sản phẩm không tồn tại";
                view.data = null;
                if (pro != null)
                {
                    double st = ((((int)productFeedDTOs.star) + ((int)pro.Feedback)) / 2);
                    pro.Feedback = (int)st;
                    _productReponsitory.UpdateProduct(pro);
                    _productReponsitory.IsSaveChanges();
                    view.Status = "Success";
                    view.Message = "Thành công";
                    view.data = feed;
                }
                
            }
            return view;  
        }

        public ViewProductDTO AddProduct(ProductDTO productDTO)
        {
            var pro = _context.Categories.FirstOrDefault(c => c.Id == productDTO.IdCate);
            var products = new Products();
            var view = new ViewProductDTO()
            {
                Status = "Error",
                Message = "Không có loại hàng này.",
                data = null
            };
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
                view.Status = "Success";
                view.Message = "Thành công";
                view.data = products;
            }
            return view;
        }

        public ViewProductDTO Delete(int id)
        {
            var product = _productReponsitory.GetProductsByIdpro(id);
            var er = new ViewProductDTO();
            er.Status = "Error";
            er.Message = "Không tìm thấy sản phẩm.";
            er.data = null;
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
                er.Status = "Success";
                er.Message = "Xóa thành công";
                er.data = null;
            }
            return er;
            
        }

        public ProductPage GetProductAll(int page, int size)
        {
            var query = _context.Products;
            var view = new ProductPage();
            var list = new List<ProductView>();
            if(page != 0 && size != 0)
            {
                int total = query.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var data = query.Skip(((page) - 1) * size).Take(size).ToList();
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
                view.Size = size;
                view.Page = page;
                view.TotalPage = pagecount;
                view.data = list;
            }else{
                foreach (Products i in query)
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
                view.Size = 0;
                view.Page = 0;
                view.TotalPage = 0;
                view.data = list;
            }
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

        public ProductAPI GetProductsByName(string name,int page, int size)
        {
            var pro = _productReponsitory.GetProductsbyName(name);
            var rs = new ProductAPI();
            var list = new List<ProductView>();
            var product = new ProductPage();
            if (pro != null)
            {
                if(page != 0 && size != 0)
                {
                    int total = pro.Count();
                    int pagecount = total / size;
                    float Page = total % size;
                    if (Page > 0) { pagecount = pagecount + 1; }
                    var data = pro.Skip(((page) - 1) * size).Take(size).ToList();
                    foreach (Products i in data)
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
                    product.Size = size;
                    product.Page = page;
                    product.TotalPage = pagecount;
                    product.data = list;
                    rs.keyword = name;
                    rs.data = product;
                }else{
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
                    product.Size = 0;
                    product.Page = 0;
                    product.TotalPage = 0;
                    product.data = list;
                    rs.keyword = name;
                    rs.data = product;
                }
                
            }
            return rs;
        }

        public CategoryAPI GetProductNameByPrice(string name, int st, int end, int page, int size)
        {
            var pros = _productReponsitory.GetProductsbyName(name).OrderBy(c=>c.Price);
            var proprice = pros.Where(c => c.Price > st).Where(c => c.Price < end);
            var list = new List<ProductView>();
            var productPage = new ProductPage();
            var view = new CategoryAPI();
            if(page != 0 && size != 0)
            {
                int total = proprice.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var data = proprice.Skip(((page) - 1) * size).Take(size).ToList();
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
                    productPage.Size = size;
                    productPage.Page = page;
                    productPage.TotalPage = pagecount;
                    productPage.data = list;
                    view.Title = name;
                    view.data = productPage;
                }
            }else{
                foreach (Products i in proprice)
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
                    productPage.Size = 0;
                    productPage.Page = 0;
                    productPage.TotalPage = 0;
                    productPage.data = list;
                    view.Title = name;
                    view.data = productPage;
                }
            }
            return view;
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
            var query = _context.Products.Where(c => c.IdCate == categoryId).ToList();
            var list = new List<ProductView>();
            var product = new ProductPage();
            var view = new CategoryAPI();
            if(page != 0 && size != 0)
            {
                int total = query.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var data = query.Skip(((page) - 1) * size).Take(size).ToList();
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
                product.Size = size;
                product.Page = page;
                product.TotalPage = pagecount;
                product.data = list;
                view.Title = title;
                view.data = product;
            }else{
                var title = _productReponsitory.GetCateById(categoryId).CategoryType;
                foreach (Products i in query)
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
                product.Size = 0;
                product.Page = 0;
                product.TotalPage = 0;
                product.data = list;
                view.Title = title;
                view.data = product;
            }   
            return view;
        }
        public ViewProductDTO UpdateProduct(int id, ProductDTO productDTOs)
        {
            var product = _productReponsitory.GetProductsByIdpro(id);
            var view = new ViewProductDTO()
            {
                Status = "Error",
                Message = "Sản phẩm không tồn tại",
                data = null
            };
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
                view.Status = "Success";
                view.Message = "Thành công";
                view.data = product;
            }
            return view;
        }
        public List<ProductView> GetProductByDate(int size)
        {
            var pros = from s in _context.Products
                       orderby s.DateCreate descending
                       select s;
            var list = new List<ProductView>();
            if(size != 0)
            {
                var data = pros.Skip(0).Take(size).ToList();
                foreach (Products i in data)
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
            }else{
                foreach (Products i in pros)
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
            return list;
        }

        public CategoryAPI GetProductByPrice(int categoryId, int st, int end, int page, int size)
        {
            var pros = from s in _context.Products.Where(c => c.IdCate == categoryId)
                       orderby s.Price select s;
            var proprice = pros.Where(c => c.Price > st).Where(c => c.Price < end);
            var list = new List<ProductView>();
            var productPage = new ProductPage();
            var view = new CategoryAPI();
            if(page != 0 && size != 0)
            {
                int total = proprice.Count();
                int pagecount = total / size;
                float Page = total % size;
                if (Page > 0) { pagecount = pagecount + 1; }
                var data = proprice.Skip(((page) - 1) * size).Take(size).ToList();
                var catevalue = _context.Categories.FirstOrDefault(c => c.Id ==categoryId);
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
                        Cate = catevalue.CategoryType
                    };
                    list.Add(proview);
                    productPage.Size = size;
                    productPage.Page = page;
                    productPage.TotalPage = pagecount;
                    productPage.data = list;
                    view.Title = catevalue.CategoryType;
                    view.data = productPage;
                }
            }else{
                var catevalue = _context.Categories.FirstOrDefault(c => c.Id ==categoryId);
                foreach (Products i in proprice)
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
                        Cate = catevalue.CategoryType
                    };
                    list.Add(proview);
                    productPage.Size = 0;
                    productPage.Page = 0;
                    productPage.TotalPage = 0;
                    productPage.data = list;
                    view.Title = catevalue.CategoryType;
                    view.data = productPage;
                }
            }
            return view;
        }

        public ViewCategory AddCategory(CategoryDTO categoryDTO)
        {
            var er = new ViewCategory();
            var cate = new ProductCate
            {
                CategoryType = categoryDTO.CategoryType
            };
            _productReponsitory.InsertCategory(cate);
            _productReponsitory.IsSaveChanges();
            er.Status = "Success";
            er.Message = "Thêm thành công";
            er.data = cate;
            return er;
        }

        public ViewCategory UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            var er = new ViewCategory();
            var cate = _productReponsitory.GetCateById(id);
            er.Status = "Error/Success";
            er.Message = "Category không tồn tại.";
            er.data = null;
            if(cate != null)
            {
                cate.CategoryType = categoryDTO.CategoryType;
                _productReponsitory.UpdateCategory(cate);
                _productReponsitory.IsSaveChanges();
                er.Status = "Success";
                er.Message = "thành công";
                er.data = cate;
            }
            return er;
        }

        public ViewCategory DeleteCate(int id)
        {
            var er = new ViewCategory();
            var cate = _productReponsitory.GetCateById(id);
            er.Status = "Error/Success";
            er.Message = "Category không tồn tại.";
            er.data = null;
            if(cate != null)
            {
                _productReponsitory.DeleteCategory(cate);
                _productReponsitory.IsSaveChanges();
                er.Status = "Success";
                er.Message = "Xóa thành công";
                er.data = cate;
            }
            return er;
        }
    }
}