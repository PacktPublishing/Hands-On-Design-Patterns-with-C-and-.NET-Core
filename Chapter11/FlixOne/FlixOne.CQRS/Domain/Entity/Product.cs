using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixOne.CQRS.Domain.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}