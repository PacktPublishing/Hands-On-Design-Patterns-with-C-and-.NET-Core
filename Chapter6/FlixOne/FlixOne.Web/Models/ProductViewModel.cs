using System;
using System.ComponentModel;

namespace FlixOne.Web.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [DisplayName("Image")]
        public string ProductImage { get; set; }
        [DisplayName("Price (INR)")]
        public decimal ProductPrice { get; set; }
        public Guid CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Product Desc.")]
        public string CategoryDescription { get; set; }
    }
}
