using ECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using Order.API.Entities;

namespace Order.API.OrderRepository
{
    public class OrderRepository : GenericRepository<OrderList> ,  IOrderRepository
    {
        private readonly OrderDBContext _orderContext;

        public OrderRepository(OrderDBContext orderContext) : base(orderContext) 
        {
            _orderContext = orderContext;
        }

        public async Task<IEnumerable<OrderList>> GetOrders()
        {
            return await _orderContext.Orders.ToListAsync();
        }
    }
}
