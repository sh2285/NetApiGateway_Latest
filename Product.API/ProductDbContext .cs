using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using System.Collections.Generic;

namespace Product.API
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductList> Products { get; set; }
    }
}
