using System;
using System.Collections.Generic;
using SimpleLogin.Models;

namespace SimpleLogin.Persistance
{
    public interface IInventoryRepositry
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool RemoveProduct(Product product);
        IEnumerable<Category> GetCategories();
        Category GetCategory(Guid id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool RemoveCategory(Category category);
    }
}