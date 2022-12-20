using BookStore.API.Data.Enities.Product;
using BookStore.API.DTO;
using BookStore.API.DTO.Product;
using BookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<ViewProductDTO> AddBook([FromForm] ProductDTO productDTO)
        {
            return Ok(_productService.CreateProduct(productDTO));
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("productFeed")]
        public ActionResult<ViewProductFeedDTO> AddProductFeed([FromForm] ProductFeedDTO productFeedDTOs)
        {
            return Ok(_productService.AddProductFeed(productFeedDTOs));
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("{name}")]
        public ActionResult<ProductAPI> GetFindBookByName(string name, int page, int size)
        {
            var pro = _productService.GetProductsByName(name,page,size);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("{id:int}")]
        public ActionResult<ProductView> GetFindBookById(int id)
        {
            var pro = _productService.GetProductById(id);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("orderby")]
        public ActionResult<List<ProductView>> GetProductByDate(int size)
        {
            var pro = _productService.GetProductByDate(size);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("orderby/{name}")]
        public ActionResult<ProductAPI> GetProductName(string name, int page, int size)
        {
            var pro = _productService.GetProductsByName(name, page,size);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("orderby/Price/{idcate}")]
        public ActionResult<ProductPage> GetProductByPrice(int idcate, int star, int end, int page, int size)
        {
            var pro = _productService.GetProductByPrice(idcate, star,end, page, size);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet()]
        public ActionResult<ProductPage> GetProductPage(int page, int size)
        {
            var pro = _productService.GetProductAll(page, size);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("category/{id}")]
        public ActionResult<CategoryAPI> GetFindBookByCategory(int id, int page, int size)
        {
            var pro = _productService.GetProductsByCategory(id, page, size);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("productFeed/{id}")]
        public ActionResult<List<FeedDTO>> GetFeedByBook(int id)
        {
            var pro = _productService.GetProductFeedById(id);
            if (pro == null) return NotFound();
            return pro;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("categories")]
        public ActionResult<ProductCate> GetAllCate() => Ok(_productService.GetProductCate());

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult<ViewProductDTO> UpdateBook(int id, [FromForm] ProductDTO productDTOs)
        {
            return Ok(_productService.UpdateProduct(id, productDTOs));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id));

        }
    }
}
