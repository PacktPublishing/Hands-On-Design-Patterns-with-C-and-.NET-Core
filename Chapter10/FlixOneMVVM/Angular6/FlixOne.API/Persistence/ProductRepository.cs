using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.API.Contexts;
using FlixOne.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.API.Persistence
{
    /// <inheritdoc />
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        /// <inheritdoc />
        public ProductRepository(ProductContext context) => _context = context;

        /// <summary>
        /// Product Listing
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll() => _context.Products.Include(c => c.Category).ToList();

        /// <summary>
        /// Get Product by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetBy(Guid id) => _context.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">Product model</param>
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove a specific Product
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Guid id)
        {
            var product = GetBy(id);
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}