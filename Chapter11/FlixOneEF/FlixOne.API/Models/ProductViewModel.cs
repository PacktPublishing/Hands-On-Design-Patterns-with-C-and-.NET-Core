using System;

namespace FlixOne.API.Models
{
    /// <summary>
    /// Product View model to Save product item
    /// </summary>
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid CategoryId { get; set; }
    }
}