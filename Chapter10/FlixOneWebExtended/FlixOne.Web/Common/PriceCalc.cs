using System;

namespace FlixOne.Web.Common
{
    public static class PriceCalc
    {
        public static decimal Discount(this decimal price, decimal discount)
        {
            return price * discount / 100;
        }

        public static decimal Discount(this decimal price, ValidDiscount validDiscount)
        {
            return price * validDiscount.Discount / 100;
        }

        public static decimal PriceAfterDiscount(this decimal price, decimal discount)
        {
            return decimal.Round(price - Discount(price, discount));
        }
    }
}

namespace System
{
    public struct ValidDiscount
    {
     private decimal _discount;
        public decimal Discount
        {
            get => _discount;
            set
            {
                if (value <= 0 || value % 100 > 1)
                    throw new ArgumentOutOfRangeException($"Valid discount values are 1 .. 100");
                _discount = value;
            }
        }
    }
}