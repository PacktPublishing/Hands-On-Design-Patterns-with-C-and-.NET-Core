using System;
using System.Collections.Generic;
using FlixOne.Common.Models;

namespace FlixOne.CQRS.Queries.Query
{
    public class ProductQuery : IQuery<IEnumerable<Product>>
    {
    }

    public class SingleProductQuery : IQuery<Product>
    {
        public SingleProductQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
        
    }
}