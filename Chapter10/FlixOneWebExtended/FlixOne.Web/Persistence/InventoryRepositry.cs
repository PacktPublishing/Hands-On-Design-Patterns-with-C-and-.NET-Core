using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlixOne.Web.Common;
using FlixOne.Web.Contexts;
using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

        public IEnumerable<Product> GetProducts(Sort sort)
        {
            if(sort.ColName==null)
                sort.ColName = "";
            switch (sort.ColName.ToLower())
            {
                case "categoryname":
                {
                    var products = sort.Order == SortOrder.A
                        ? ListProducts().OrderBy(x => x.Category.Name)
                        : ListProducts().OrderByDescending(x => x.Category.Name);
                    return PDiscounts(products);

                }
                case "ProductDescription":
                {
                    var products = sort.Order == SortOrder.A
                        ? ListProducts().OrderBy(x => x.Description)
                        : ListProducts().OrderByDescending(x => x.Description);
                    return PDiscounts(products);

                }
                case "productname":
                {
                    var products = sort.Order == SortOrder.A
                        ? ListProducts().OrderBy(x => x.Name)
                        : ListProducts().OrderByDescending(x => x.Name);
                    return PDiscounts(products);
                }
                case "productprice":
                {
                    var products = sort.Order == SortOrder.A
                        ? ListProducts().OrderBy(x => x.Price)
                        : ListProducts().OrderByDescending(x => x.Price);
                    return PDiscounts(products);
                }
                default:
                    return PDiscounts(ListProducts().OrderBy(x => x.Name));
            }
        }

        private List<Product> PDiscounts(IOrderedQueryable<Product> products)
        {
            var pDiscounts = new List<Product>();

            products.AsNoTracking().ToList().ForEach(product =>
            {
                product.Discount = GetDiscountBy(product.Id);
                pDiscounts.Add(product);
            });
            return pDiscounts;
        }

        private IIncludableQueryable<Product, Category> ListProducts() =>
            _inventoryContext.Products.Include(c => c.Category);

        public Product GetProduct(Guid id) =>
            _inventoryContext.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);

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
                ? GetDiscountList().CustomWhere(d => d.ProductId == productId && d.Active)
                : GetDiscountList().CustomWhere(d => d.ProductId == productId);
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