using ECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using Product.API.Entities;

namespace Product.API.ProductRepository
{
    public class ProductRepository : GenericRepository<ProductList>, IProductRepository
    {
        private readonly ProductDbContext _productContext;

        public ProductRepository(ProductDbContext context) : base(context)
        {
            _productContext = context;
        }

        public async Task<IEnumerable<ProductList>> GetExpensiveProducts()
        {
            return await _productContext.Products
                .Where(p => p.Price > 10000)
                .ToListAsync();
        }
    }
}
