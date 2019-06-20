using System;

namespace FlixOne.API.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique Product Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Product icon
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Product Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Unique Category Id
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public virtual Category Category { get; set; }
    }
}