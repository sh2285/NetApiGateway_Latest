using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.API.Entities;
using Order.API.Services;

namespace Order.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderList>>> GetAll()
        {
            _logger.LogInformation("Request received to fetch all orders");

            var orders = await _orderService.GetAllAsyncOrders();

            if (orders == null || !orders.Any())
            {
                _logger.LogWarning("No orders found");
                return NotFound(new { message = "No orders available" });
            }

            _logger.LogInformation("Returning {Count} orders", orders.Count());
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<OrderList>> Create([FromBody] OrderList order)
        {
            _logger.LogInformation("Request received to create an order");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for order creation");
                return BadRequest(ModelState);
            }

            var createdOrder = await _orderService.CreateOrders(order);

            if (createdOrder == null)
            {
                _logger.LogWarning("Order creation failed");
                return StatusCode(500, new { message = "Failed to create order" });
            }

            _logger.LogInformation("Order created with ID: {Id}", createdOrder.Id);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = createdOrder.Id },
                createdOrder
            );
        }
    }
}
