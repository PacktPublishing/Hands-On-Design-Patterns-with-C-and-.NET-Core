using Microsoft.EntityFrameworkCore;
using SimpleLogin.Models;

namespace SimpleLogin.Contexts
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
        public DbSet<User>Users { get; set; }
    }
}