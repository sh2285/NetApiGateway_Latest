using Order.API.Entities;

namespace Order.API.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Entities.OrderList>> GetAllAsyncOrders();
        Task<Entities.OrderList> CreateOrders(Entities.OrderList orders);
    }
}
