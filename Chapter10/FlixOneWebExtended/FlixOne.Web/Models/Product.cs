using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixOne.Web.Models
{
    public class Product
    {
        public Product()
        {
            Discount = new List<Discount>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual IEnumerable<Discount> Discount { get; set; }
    }

    /// <summary>
    ///     Purpos of this class is
    ///     to set various discount offers eg. seasonl dis, special disc etc.
    ///     only one discount offer will be active at time.
    /// </summary>
    public class Discount
    {
        public Guid Id { get; set; }
        public decimal DiscountRate { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Guid ProductId { get; set; }

        [NotMapped] public string ProductName { get; set; }

        [NotMapped] public decimal ProductPrice { get; set; }
    }
}