using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public class Helper : IHelper
    {
        private static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;
        private readonly Predicate<string> _isProductNameTitleCase = s => s.Equals(TextInfo.ToTitleCase(s));
        private readonly Func<decimal, bool> _vallidDiscount = d => d == 0 || d - 100 <= 1;

        public IEnumerable<DiscountViewModel> FilterOutInvalidDiscountRates(
            IEnumerable<DiscountViewModel> discountViewModels)
        {
            var viewModels = discountViewModels.ToList();
            var res = viewModels.Select(x => x.ProductDiscountRate).Where(_vallidDiscount);
            return viewModels.Where(x => res.Contains(x.ProductDiscountRate));
        }

        public IEnumerable<ProductViewModel> FilterOutInvalidProductNames(
            IEnumerable<ProductViewModel> productViewModels) => productViewModels.ToList()
            .Where(p => _isProductNameTitleCase(p.ProductName));

        public IEnumerable<ProductViewModel>
            GetProductsAbovePrice(IEnumerable<ProductViewModel> productViewModels, decimal price) =>
            productViewModels.SimplifiedWhere(p => p.ProductPrice > price);
    }

    public interface IHelper
    {
        IEnumerable<DiscountViewModel> FilterOutInvalidDiscountRates(
            IEnumerable<DiscountViewModel> discountViewModels);

        IEnumerable<ProductViewModel> FilterOutInvalidProductNames(
            IEnumerable<ProductViewModel> productViewModels);
    }
}