using Product.API.Entities;

namespace Product.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductList>> GetAllAsync();
        Task<ProductList> CreateAsync(ProductList product);
    }
}
