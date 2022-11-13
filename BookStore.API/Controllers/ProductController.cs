using BookStore.API.Data;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DTOs.Product;
using BookStore.API.Services;
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

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromForm] ProductDTOs productDTOs,[FromForm] CategoryDTOs categoryDTOs)
        {
            var products = new Products
            {
                Name = productDTOs.Name,
                Desc = productDTOs.Desc,
                Image = productDTOs.Image,
                Feedback = productDTOs.Feedback,
                Frice = productDTOs.Price,
                Quantity = productDTOs.Quantity,
                Discount = productDTOs.Discount,
                IdCate = categoryDTOs.Id
            };
            _context.Products.Add(products);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet("{name}")]
        public IActionResult GetFindBookByName(string name)
        {
            return  Ok(_context.Products.Where(c => c.Name.Contains(name)).ToList());
        }
        [HttpGet("Find/{category}")]
        public IActionResult GetFindBookByCategory(int category)
        {
            return  Ok(_context.Products.Where(c => c.IdCate == category).ToList());
        }
        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Products.ToList());

        [HttpPut("Update")]
        public IActionResult UpdateBook([FromForm] ProductDTOs productDTOs)
        {
            var result = _context.Update(productDTOs);
            if (result == null)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            return Ok();
        }
    }
}