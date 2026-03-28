using Product.API.Entities;
using Product.API.Models;
using Product.API.ProductRepository;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, ILogger<ProductService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductList>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all products");

                var products = await _repository.GetAllAsync();

                _logger.LogInformation("Successfully fetched {Count} products", products.Count());

                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all products");
                throw;
            }
        }

        public async Task<ProductList> CreateAsync(ProductList product)
        {
            try
            {
                _logger.LogInformation("Creating product: {Name}", product.Name);

                var created = await _repository.AddAsync(product);

                _logger.LogInformation("Successfully created product with ID: {Id}", created.Id);

                return created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating product: {Name}", product.Name);
                throw;
            }
        }
    }
}
