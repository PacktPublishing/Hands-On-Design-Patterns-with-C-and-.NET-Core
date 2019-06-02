using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Common;
using FlixOne.Web.Contexts;
using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Persistence
{
    public class InventoryRepositry : IInventoryRepositry
    {
        private readonly IHelper _helper;
        private readonly InventoryContext _inventoryContext;

        public InventoryRepositry(InventoryContext inventoryContext, IHelper helper)
        {
            _inventoryContext = inventoryContext;
            _helper = helper;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _inventoryContext.Products.Include(c => c.Category).ToList();
            var pDiscounts = new List<Product>();
            products.ForEach(product =>
            {
                product.Discount = GetDiscountBy(product.Id);
                pDiscounts.Add(product);
            });
            return pDiscounts;
        }

        public Product GetProduct(Guid id)
        {
            return _inventoryContext.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);
        }

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

        public IEnumerable<Category> GetCategories()
        {
            return _inventoryContext.Categories.ToList();
        }

        public Category GetCategory(Guid id)
        {
            return _inventoryContext.Categories.FirstOrDefault(x => x.Id == id);
        }

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

        public IEnumerable<Discount> GetDiscounts()
        {
            var disList = GetDiscountList().Select(d => d.ProductId).Distinct().ToList();
            var listDiscounts = new List<Discount>();
            foreach (var discount in disList)
            {
                listDiscounts.AddRange(GetDiscountBy(discount));
            }

            return listDiscounts;
        }

        private List<Discount> GetDiscountList()
        {
            return _inventoryContext.Discounts.ToList();
        }

        public IEnumerable<Discount> GetDiscountBy(Guid productId, bool activeOnly = false)
        {
            var discounts = activeOnly
                ? GetDiscountList().Where(d => d.ProductId == productId && d.Active)
                : GetDiscountList().Where(d => d.ProductId == productId);
            var product = _inventoryContext.Products.FirstOrDefault(p => p.Id == productId);
            var listDis = new List<Discount>();
            foreach (var discount in discounts)
            {
                if (product != null)
                {
                    discount.ProductName = product.Name;
                    discount.ProductPrice = product.Price;
                }

                listDis.Add(discount);
            }

            return listDis;
        }

        public IEnumerable<DiscountViewModel> GetValidDiscoutedProducts(
            IEnumerable<DiscountViewModel> discountViewModels)
        {
            return _helper.FilterOutInvalidDiscountRates(discountViewModels);
        }
    }
}