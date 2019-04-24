using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleLogin.Contexts;
using SimpleLogin.Models;

namespace SimpleLogin.Persistance
{
    public class InventoryRepositry : IInventoryRepositry
    {
        private readonly InventoryContext _context;

        public InventoryRepositry(InventoryContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll() => _context.Products.Include(c => c.Category).ToList();
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(c => c.Category).ToList();
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);
        }

        public bool AddProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveProduct(Product product)
        {
            _context.Remove(product);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(Guid id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public bool AddCategory(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveCategory(Category category)
        {
            _context.Remove(category);
            return _context.SaveChanges() > 0;
        }
    }
}