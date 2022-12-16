using AutoMapper.Execution;
using BookStore.API.Data.Enities.Product;
using BookStore.API.DTO;
using BookStore.API.DTO.Product;
using BookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddBook([FromForm] ProductDTO productDTO)
        {
            return Ok(_productService.CreateProduct(productDTO));
        }

        [HttpPost("productFeed")]
        public IActionResult AddProductFeed([FromForm] ProductFeedDTO productFeedDTOs)
        {
            return Ok(_productService.AddProductFeed(productFeedDTOs));
        }

        [HttpGet("{name}")]
        public ActionResult<ProductAPI> GetFindBookByName(string name)
        {
            var pro = _productService.GetProductByName(name);
            if (pro == null) return NotFound();
            return pro;
        }

        [HttpGet("{page}and{size}")]
        public ActionResult<ProductPage> GetProductPage(int page, int size)
        {
            var pro = _productService.GetProductAll(page, size);
            if (pro == null) return NotFound();
            return pro;
        }

        [HttpGet("category/{id}and{page}and{size}")]
        public ActionResult<CategoryAPI> GetFindBookByCategory(int id, int page, int size)
        {
            var pro = _productService.GetProductsByCategory(id, page, size);
            if (pro == null) return NotFound();
            return pro;
        }

        [HttpGet("productFeed/{id}")]
        public ActionResult<List<FeedDTO>> GetFeedByBook(int id)
        {
            var pro = _productService.GetProductFeedById(id);
            if (pro == null) return NotFound();
            return pro;
        }
        [HttpGet("category")]
        public ActionResult<ProductCate> GetAllCate() => Ok(_productService.GetProductCate());

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromForm] ProductDTO productDTOs)
        {
            return Ok(_productService.UpdateProduct(id, productDTOs));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id));

        }
    }
}
