using Order.API.Entities;
using Order.API.OrderRepository;

namespace Order.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderList>> GetAllAsyncOrders()
        {
            try
            {
                _logger.LogInformation("Fetching all orders");

                var orders = await _orderRepository.GetAllAsync();

                _logger.LogInformation("Successfully fetched {Count} orders", orders.Count());

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all orders");
                throw;
            }
        }

        public async Task<OrderList> CreateOrders(OrderList order)
        {
            try
            {
                _logger.LogInformation("Creating order with ID: {Id}", order.Id);

                var createdOrder = await _orderRepository.AddAsync(order);

                _logger.LogInformation("Successfully created order with ID: {Id}", createdOrder.Id);

                return createdOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating order with ID: {Id}", order.Id);
                throw;
            }
        }
    }
}
