using System;
using System.Collections.Generic;
using FlixOne.CQRS.Domain.Entity;

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