using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Contexts
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public InventoryContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }

    }
}