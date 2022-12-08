using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Book")]
        public IActionResult AddBook([FromForm] ProductDTOs productDTOs)
        {
            var products = new Products
            {
                Name = productDTOs.Name,
                Desc = productDTOs.Desc,
                Image = productDTOs.Image,
                Frice = productDTOs.Price,
                Quantity = productDTOs.Quantity,
                DateCreate = DateTime.Now,
                Discount = productDTOs.Discount,
                IdCate = productDTOs.IdCate
            };
            _context.Products.Add(products);
            _context.SaveChanges();

            return Ok();
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
            _context.ProductFeeds.Add(feed);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("Name/{name}")]
        public IActionResult GetFindBookByName(string name)
        {
            return  Ok(_context.Products.Where(c => c.Name.Contains(name)).ToList());
        }

        [HttpGet("Categrory/{category}")]
        public IActionResult GetFindBookByCategory(int category)
        {
            return  Ok(_context.Products.Where(c => c.IdCate == category).ToList());
        }

        [HttpGet("ProductFeed/{id}")]
        public IActionResult GetFeedByBook(int id)
        {
            return  Ok(_context.ProductFeeds.Where(c => c.ProductID == id).ToList());
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Products.ToList());

        [HttpGet("Category")]
        public IActionResult GetAllCate() => Ok(_context.Categories.ToList());

        [HttpPut("{Id}")]
        public IActionResult UpdateBook(int Id,[FromForm] ProductDTOs productDTOs)
        {
            var product = _context.Products.FirstOrDefault(c => c.IdProduct == Id);
            if (product != null)
            {
                product.Name = productDTOs.Name;
                product.Image = productDTOs.Image;
                product.Desc = productDTOs.Desc;
                product.Frice = productDTOs.Price;
                product.Quantity = productDTOs.Quantity;
                product.Discount = productDTOs.Discount;
                product.IdCate = productDTOs.IdCate;
            }
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(c => c.IdProduct == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(product);
            }
            return Unauthorized("Không có sản phẩm");
        }
    }
}