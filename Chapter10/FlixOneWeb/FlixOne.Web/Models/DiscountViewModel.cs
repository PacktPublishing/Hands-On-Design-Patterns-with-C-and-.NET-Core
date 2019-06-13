using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlixOne.Web.Models
{
    public class DiscountViewModel
    {
        public Guid ProductId { get; set; }
        [DisplayName("Product Name")] public string ProductName { get; set; }
        [DisplayName("Price (INR)")]  public decimal Price { get; set; }
        [DisplayName("Discount Rate")] [DisplayFormat(DataFormatString = @"{0:#\%}")] public decimal ProductDiscountRate { get; set; }
        [DisplayName("Description")] public string Description { get; set; }
        [DisplayName("Active?")] public string Active { get; set; }
        [DisplayName("Remarks, if any")] public string Remarks { get; set; }
    }
}