using System.Collections.Generic;
using FlixOne.Common.Models;
using FlixOne.CQRS.Queries.Handler;

namespace FlixOne.CQRS.Queries.Query
{
    public static class ProductQueryHandlerFactory
    {
        public static IQueryHandler<ProductQuery, IEnumerable<Product>> Build(ProductQuery productQuery)
        {
            return new ProductQueryHandler();
        }

        public static IQueryHandler<SingleProductQuery, Product> Build(SingleProductQuery singleProductQuery)
        {
            return  new SingleProductQueryHandler(singleProductQuery);
        }
    }
}