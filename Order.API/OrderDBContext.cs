using Microsoft.EntityFrameworkCore;
using Order.API.Entities;

namespace Order.API
{
    public class OrderDBContext:DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options):base(options)
        { 
        }

        public DbSet<OrderList> Orders {  get; set; }
    }
}
