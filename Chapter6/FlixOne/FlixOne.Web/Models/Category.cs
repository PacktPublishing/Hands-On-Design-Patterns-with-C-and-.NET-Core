using System;
using System.Collections.Generic;

namespace FlixOne.Web.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
