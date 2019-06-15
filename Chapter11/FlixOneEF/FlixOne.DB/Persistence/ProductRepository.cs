using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlixOne.Common.Models;
using FlixOne.DB.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.DB.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository()
        {
           _context = new ProductContext(DbContextOptionsBuilder().Options);
        }

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll() => _context.Products.Include(c => c.Category).ToList();

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.Include(c => c.Category).ToListAsync();

        public Product GetBy(Guid id) => _context.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);

        public void Remove(Guid id)
        {
            var product = GetBy(id);
            _context.Remove(product);
        }

        public void Update(Product product) => _context.Update(product);

        private static DbContextOptionsBuilder<ProductContext> DbContextOptionsBuilder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=FlixOneEFCore;Integrated Security=True;MultipleActiveResultSets=True",
                assembly => assembly.MigrationsAssembly(typeof(ProductContext).Assembly.FullName));
            return optionsBuilder;
        }
    }
}