using System;
using System.Collections.Generic;
using FlixOne.CQRS.Domain.Entity;
using FlixOne.CQRS.Queries.Query;

namespace FlixOne.CQRS.Queries.Handler
{
    public class ProductQueryHandler : IQueryHandler<ProductQuery, IEnumerable<Product>>
    {
        public IEnumerable<Product> Get()
        {
            //call repository
            throw new NotImplementedException();
        }
    }
    public class SingleProductQueryHandler : IQueryHandler<SingleProductQuery, Product>
    {
        private SingleProductQuery _productQuery;
        public SingleProductQueryHandler(SingleProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public Product Get()
        {
            //call repository
            throw new NotImplementedException();
        }
    }
}
