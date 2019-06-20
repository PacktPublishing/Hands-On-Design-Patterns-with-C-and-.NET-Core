using FlixOne.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.API.Contexts
{
    /// <inheritdoc />
    public class ProductContext : DbContext
    {
        /// <inheritdoc />
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        /// <inheritdoc />
        public ProductContext()
        {
        }
        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }
    }
}