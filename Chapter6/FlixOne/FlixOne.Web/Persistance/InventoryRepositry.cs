using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Contexts;
using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Persistance
{
    public class InventoryRepositry : IInventoryRepositry
    {
        private readonly InventoryContext _inventoryContext;

        public InventoryRepositry(InventoryContext inventoryContext) => _inventoryContext = inventoryContext;

        public IEnumerable<Product> GetProducts() => _inventoryContext.Products.Include(c => c.Category).ToList();

        public Product GetProduct(Guid id) => _inventoryContext.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);

        public bool AddProduct(Product product)
        {
            _inventoryContext.Products.Add(product);
            return _inventoryContext.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product)
        {
            _inventoryContext.Update(product);
            return _inventoryContext.SaveChanges() > 0;
        }

        public bool RemoveProduct(Product product)
        {
            _inventoryContext.Remove(product);
            return _inventoryContext.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetCategories() => _inventoryContext.Categories.ToList();

        public Category GetCategory(Guid id) => _inventoryContext.Categories.FirstOrDefault(x => x.Id == id);

        public bool AddCategory(Category category)
        {
            _inventoryContext.Categories.Add(category);
            return _inventoryContext.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _inventoryContext.Update(category);
            return _inventoryContext.SaveChanges() > 0;
        }

        public bool RemoveCategory(Category category)
        {
            _inventoryContext.Remove(category);
            return _inventoryContext.SaveChanges() > 0;
        }
    }
}