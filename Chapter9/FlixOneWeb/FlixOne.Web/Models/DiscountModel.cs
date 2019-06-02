using System;

namespace FlixOne.Web.Models
{
    public class DiscountViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
    }
}
