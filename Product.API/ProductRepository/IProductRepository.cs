using ECommerce.Repositories;
using Product.API.Entities;

namespace Product.API.ProductRepository
{
    public interface IProductRepository : IGenericRepository<ProductList>
    {
        Task<IEnumerable<ProductList>> GetExpensiveProducts();
    }
}
