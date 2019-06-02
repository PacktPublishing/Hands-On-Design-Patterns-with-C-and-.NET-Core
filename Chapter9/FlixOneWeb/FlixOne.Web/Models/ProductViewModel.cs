using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlixOne.Web.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        [DisplayName("Product Name")] public string ProductName { get; set; }
        [DisplayName("Description")] public string ProductDescription { get; set; }
        [DisplayName("Image")] public string ProductImage { get; set; }
        [DisplayName("Price (INR)")] public decimal ProductPrice { get; set; }
        public Guid CategoryId { get; set; }
        [DisplayName("Category Name")] public string CategoryName { get; set; }
        [DisplayName("Product Desc.")] public string CategoryDescription { get; set; }
        [DisplayName("Discount Rate")] [DisplayFormat(DataFormatString = @"{0:#\%}")] public decimal ProductDiscountRate { get; set; }
        [DisplayName("Discount (INR)")]  public decimal ProductDiscount { get; set; }
        [DisplayName("Net Price (INR)")] public decimal ProductNetPrice { get; set; }


    }
}
