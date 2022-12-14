using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DTOs.Product;
using BookStore.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        public IActionResult GetFindBookByName(string name)
        {
            return  Ok(_productService.GetProductsbyName(name));
        }

        [HttpGet("Categrory/{category}")]
        public IActionResult GetFindBookByCategory(int category)
        {
            return  Ok(_productService.GetProductsByCategory(category));
        }

        [HttpGet("ProductFeed/{id}")]
        public IActionResult GetFeedByBook(int id)
        {
            return  Ok(_productService.GetProductFeedById(id));
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_productService.GetProducts());

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