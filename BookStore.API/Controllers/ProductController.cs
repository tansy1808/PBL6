using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DTOs.Product;
using BookStore.API.DTOs.Views;
using BookStore.API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookStore.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly DataContext context;

        public ProductController(IProductService productService, DataContext context)
        {
            _productService = productService;
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddBook([FromForm] ProductDTOs productDTOs)
        {
            var products = new Products
            {
                Name = productDTOs.Name,
                Desc = productDTOs.Desc,
                Image = productDTOs.Image,
                Price = productDTOs.Price,
                Quantity = productDTOs.Quantity,
                DateCreate = DateTime.Now,
                Discount = productDTOs.Discount,
                IdCate = productDTOs.IdCate
            };
            _productService.InsertProduct(products);
            _productService.IsSaveChanges();

            return Ok(products);
        }

        [HttpPost("ProductFeed")]
        public IActionResult AddProductFeed([FromForm] ProductFeedDTOs productFeedDTOs)
        {
            var feed = new ProductFeed
            {
                Star = productFeedDTOs.star,
                Comment = productFeedDTOs.Comment,
                ProductID = productFeedDTOs.ProductID,
                UserID = productFeedDTOs.UserID,
                FeedDate = DateTime.Now
            };
            _productService.InsertProductFeed(feed);
            _productService.IsSaveChanges();
            return Ok(feed);
        }

        [HttpGet("Name/{name}")]
        public ActionResult<List<Products>> GetFindBookByName(string name)
        {
            return _productService.GetProductsbyName(name);
        }

        [HttpGet("Categrory/{Id}and{page}and{size}")]
        public ActionResult<List<Products>> GetFindBookByCategory(int Id, int page, int size)
        {
            return Ok(_productService.GetProductsByCategory(Id,page,size));
        }

        [HttpGet("ProductFeed/{id}")]
        public IActionResult GetFeedByBook(int id)
        {
            return  Ok(_productService.GetProductFeedById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pro = _productService.GetProductsAll();
            List<ProductViewDTOs> list = new List<ProductViewDTOs>();
            foreach (Products i in pro)
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
                    Cate = _productService.GetCateById(i.IdCate).CategoryType
                };
                list.Add(proview);

            }
            return Ok(list);
        }

        [HttpGet("ProductPage/{page}and{size}")]
        public IActionResult GetPageAll(int page, int size) 
        {
            
            return Ok(_productService.GetProductsPage(page,size));
        }

        [HttpGet("Category")]
        public IActionResult GetAllCate() => Ok(_productService.GetProductCate());

        [HttpPut("{Id}")]
        public IActionResult UpdateBook(int Id,[FromForm] ProductDTOs productDTOs)
        {
            var product = _productService.GetProductsById(Id);
            if (product != null)
            {
                product.Name = productDTOs.Name;
                product.Image = productDTOs.Image;
                product.Desc = productDTOs.Desc;
                product.Price = productDTOs.Price;
                product.Quantity = productDTOs.Quantity;
                product.Discount = productDTOs.Discount;
                product.IdCate = productDTOs.IdCate;
                _productService.UpdateProduct(product);
                _productService.IsSaveChanges();
            }
            return Ok(product);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product =_productService.GetProductsById(id);
            if (product != null)
            {
                var feed = _productService.GetProductFeedById(id);
                _productService.DeteleFeed(feed);
                _productService.DeteleProduct(product);
                _productService.IsSaveChanges();
                return Ok(product);
            }
            return Unauthorized("Không có sản phẩm");
        }
    }
}