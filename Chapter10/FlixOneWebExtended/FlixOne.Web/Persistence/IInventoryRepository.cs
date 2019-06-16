using System;
using System.Collections.Generic;
using FlixOne.Web.Models;

namespace FlixOne.Web.Persistence
{
    public interface IInventoryRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Sort sort,string searchTerm, int? pageNumber, int? pageSize);
        Product GetProduct(Guid id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool RemoveProduct(Product product);
        IEnumerable<Category> GetCategories();
        Category GetCategory(Guid id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool RemoveCategory(Category category);
        IEnumerable<Discount> GetDiscounts();
        IEnumerable<Discount> GetDiscountBy(Guid productId, bool activeOnly = false);

        IEnumerable<DiscountViewModel> GetValidDiscoutedProducts(
            IEnumerable<DiscountViewModel> discountViewModels);
    }
}