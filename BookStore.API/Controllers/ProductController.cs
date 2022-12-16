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
    [Route("api/product")]
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

        [HttpPost("productFeed")]
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

        [HttpGet("{name}")]
        public ActionResult<List<Products>> GetFindBookByName(string name)
        {
            return _productService.GetProductsbyName(name);
        }

        [HttpGet("{id}and{page}and{size}")]
        public ActionResult<List<Products>> GetFindBookByCategory(int id, int page, int size)
        {
            return Ok(_productService.GetProductsByCategory(id,page,size));
        }

        [HttpGet("productFeed/{id}")]
        public IActionResult GetFeedByBook(int id)
        {
            return  Ok(_productService.GetProductFeedById(id));
        }

        [HttpGet("productPage/{page}and{size}")]
        public IActionResult GetPageAll(int page, int size) 
        {
            
            return Ok(_productService.GetProductsPage(page,size));
        }

        [HttpGet("category")]
        public IActionResult GetAllCate() => Ok(_productService.GetProductCate());

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromForm] ProductDTOs productDTOs)
        {
            var product = _productService.GetProductsById(id);
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