using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.API.Entities;
using Product.API.Services;

namespace Product.API.Controllers
{


    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductList>>> GetAll()
        {
            _logger.LogInformation("Request received to fetch all products");

            var products = await _productService.GetAllAsync();

            if (products == null || !products.Any())
            {
                _logger.LogWarning("No products found");
                return NotFound(new { message = "No products available" });
            }

            _logger.LogInformation("Returning {Count} products", products.Count());
            return Ok(products);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductList>> Create([FromBody] ProductList product)
        {
            _logger.LogInformation("Request received to create a product");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state");
                return BadRequest(ModelState);
            }

            var createdProduct = await _productService.CreateAsync(product);

            if (createdProduct == null)
            {
                _logger.LogWarning("Product creation failed");
                return StatusCode(500, new { message = "Failed to create product" });
            }

            _logger.LogInformation("Product created with ID: {Id}", createdProduct.Id);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = createdProduct.Id },
                createdProduct
            );
        }
    }
}
