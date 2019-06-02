using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public static class Extension
    {
        public static Product ToProductModel(this ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice
            };
        }

        public static ProductViewModel ToProductvm(this Product productModel)
        {
            var discounts = new List<Discount>();
            if (productModel.Discount.Any())
            {
                productModel.Discount.ToList().ForEach(d =>
                {
                    discounts.Add(new Discount
                    {
                        Id = d.Id,
                        ProductId = d.ProductId,
                        Description = d.Description,
                        Active = d.Active,
                        DiscountRate = d.DiscountRate
                    });
                });
            }

            var productDiscountRate = discounts.FirstOrDefault(d => d.ProductId == productModel.Id && d.Active).DiscountRate;
            var productDiscount = productModel.Price.CalculateDiscount(productDiscountRate);
            var productNetprice = productModel.Price - productDiscount;
            return new ProductViewModel
            {
                CategoryId = productModel.CategoryId,
                CategoryDescription = productModel.Category.Description,
                CategoryName = productModel.Category.Name,
                ProductDescription = productModel.Description,
                ProductId = productModel.Id,
                ProductImage = productModel.Image,
                ProductName = productModel.Name,
                ProductPrice = productModel.Price,
                ProductDiscountRate = productDiscountRate,
                ProductDiscount = productDiscount,
                ProductNetPrice = productNetprice 
            };
        }

        public static decimal CalculateDiscount(this decimal price, decimal discount)
        {
            return price * discount / 100;
        }
        public static IEnumerable<Product> ToProductModel(this IEnumerable<ProductViewModel> productvm) => productvm.Select(ToProductModel).ToList();

        public static IEnumerable<ProductViewModel> ToProductvm(this IEnumerable<Product> productModel) => productModel.Select(ToProductvm).ToList();
    }
}
