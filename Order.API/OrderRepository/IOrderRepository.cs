using ECommerce.Repositories;
using Order.API.Entities;


namespace Order.API.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<OrderList>
    {
        Task<IEnumerable<OrderList>> GetOrders();
    }
}
