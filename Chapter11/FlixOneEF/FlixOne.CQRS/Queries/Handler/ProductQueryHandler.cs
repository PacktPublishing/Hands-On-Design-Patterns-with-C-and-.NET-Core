using System.Collections.Generic;
using System.Linq;
using FlixOne.Common.Models;
using FlixOne.CQRS.Queries.Query;
using FlixOne.DB.Persistence;

namespace FlixOne.CQRS.Queries.Handler
{
    public class ProductQueryHandler : IQueryHandler<ProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler()
        {
            _productRepository = new ProductRepository();
        }


        public IEnumerable<Product> Get()
        {
            var product = _productRepository.GetAll();

            return product.Select(p => new Product
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image
            });
        }

    }

    public class SingleProductQueryHandler : IQueryHandler<SingleProductQuery, Product>
    {
        private readonly SingleProductQuery _productQuery;
        private readonly IProductRepository _productRepository;
        public SingleProductQueryHandler(SingleProductQuery productQuery)
        {
            _productQuery = productQuery;
            _productRepository = new ProductRepository();
        }

        public Product Get()
        {
            var product = _productRepository.GetBy(_productQuery.Id);
            return new Product
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image
            };


        }
    }
}
