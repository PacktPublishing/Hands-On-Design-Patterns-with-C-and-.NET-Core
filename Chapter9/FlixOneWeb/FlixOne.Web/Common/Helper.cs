using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public class Helper: IHelper
    {
        private readonly Func<decimal, bool> _vallidDiscount = d => d > 0 || d % 100 <= 1;

        public IEnumerable<DiscountViewModel> FilterOutInvalidDiscountRates(
            IEnumerable<DiscountViewModel> discountViewModels)
        {
            var viewModels = discountViewModels.ToList();
            var res = viewModels.Select(x => x.Discount).Where(_vallidDiscount);
            return viewModels.Where(x => res.Contains(x.Discount));
        }
    }

    public interface IHelper
    {
        IEnumerable<DiscountViewModel> FilterOutInvalidDiscountRates(
            IEnumerable<DiscountViewModel> discountViewModels);
    }
}