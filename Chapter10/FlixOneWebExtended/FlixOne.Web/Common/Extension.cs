using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public static class Extension
    {
        private static readonly Func<decimal, bool> VallidDiscount = d => d == 0 || d - 100 <= 1;

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
            var pId = productModel.Id;
            if (productModel.Discount.Any())
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

            var discountRate =
                discounts.FirstOrDefault(d => d.ProductId == pId);
            var productDiscount = 0M;
            var productNetprice = 0M;
            var dis = 0M;
            if (discountRate != null)
            {
                dis = discountRate.DiscountRate;
                productDiscount = productModel.Price.CalculateDiscount(dis);
                productNetprice = productModel.Price - productDiscount;
            }


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
                ProductDiscountRate = dis,
                ProductDiscount = productDiscount,
                ProductNetPrice = productNetprice
            };
        }

        public static DiscountViewModel ToDiscountViewModel(this Discount discountModel)
        {
            var remarks = VallidDiscount(discountModel.DiscountRate)
                ? "-"
                : "Discount rate is invalid, hence will not consider in price calculations.";
            return new DiscountViewModel
            {
                ProductId = discountModel.ProductId,
                ProductName = discountModel.ProductName,
                Price = discountModel.ProductPrice,
                Active = discountModel.Active ? "Yes" : "No",
                Description = discountModel.Description,
                ProductDiscountRate = discountModel.DiscountRate,
                Remarks = remarks
            };
        }

        public static decimal CalculateDiscount(this decimal price, decimal discount)
        {
            return price * discount / 100;
        }

        public static IEnumerable<Product> ToProductModel(this IEnumerable<ProductViewModel> productvm)
        {
            return productvm.Select(ToProductModel).ToList();
        }

        public static IEnumerable<ProductViewModel> ToProductvm(this IEnumerable<Product> productModel)
        {
            return productModel.Select(ToProductvm).ToList();
        }

        public static IEnumerable<DiscountViewModel> ToDiscountViewModel(this IEnumerable<Discount> discountModel)
        {
            return discountModel.Select(ToDiscountViewModel).ToList();
        }

        public static IEnumerable<T> CustomWhere<T>
            (this IEnumerable<T> source, Func<T, bool> criteria)
        {
            return source.Where(item => criteria(item));
        }

        public static IEnumerable<T> SimplifiedWhere<T>
            (this IEnumerable<T> source, Func<T, bool> criteria)
        {
            return source.Where(criteria);
        }
    }
}