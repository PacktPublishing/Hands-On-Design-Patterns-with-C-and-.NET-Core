using System;
using System.Collections.Generic;

namespace FlixOne.Common.Models
{
    public class Category
    {
        public Category() => Products = new List<Product>();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}