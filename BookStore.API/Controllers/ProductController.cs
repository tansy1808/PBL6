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
                feedback = productDTOs.feedback,
                price = productDTOs.price,
                Quantity = productDTOs.Quantity,
                discount = productDTOs.discount,
                IdCate = categoryDTOs.Id
            };
            _context.SetProduct.Add(products);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet("{name}")]
        public IActionResult GetFindBookByName(string name)
        {
            try
            {
                return  Ok(_context.SetProduct.Where(c=> c.Name.ToLower() == name.ToLower()).ToList());
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_context.SetProduct.ToList());

        [HttpPut("Update")]
        public IActionResult UpdateBook([FromForm] ProductDTOs productDTOs)
        {
            var result = _context.Update(productDTOs);
            if (result == null)
                return BadRequest();
            return Ok();
        }
    }
}