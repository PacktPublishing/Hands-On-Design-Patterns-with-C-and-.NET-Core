using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlixOne.Web.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        [DisplayName("Cat Name")] public string CategoryName { get; set; }
        [DisplayName("Name")] public string ProductName { get; set; }
        [DisplayName("Description")] public string ProductDescription { get; set; }
        [DisplayName("Image")] public string ProductImage { get; set; }
        [DisplayName("Price")] public decimal ProductPrice { get; set; }
        [DisplayName("Product Desc.")] public string CategoryDescription { get; set; }

        [DisplayName("Discount Rate")]
        [DisplayFormat(DataFormatString = @"{0:#\%}")]
        public decimal ProductDiscountRate { get; set; }

        [DisplayName("Discount")] public decimal ProductDiscount { get; set; }
        [DisplayName("Net Price")] public decimal ProductNetPrice { get; set; }

    }

    public class Sort
    {
        public SortOrder Order { get; set; } = SortOrder.N;
        public string ColName { get; set; }
        public ColumnType ColType { get; set; } = ColumnType.Text;
    }

    public enum SortOrder { D, A, N }
    public enum ColumnType { Text, Date, Number }
}
