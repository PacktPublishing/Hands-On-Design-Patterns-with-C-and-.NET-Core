using System.Collections.Generic;
using System.Linq;
using FlixOne.Common.Models;

namespace FlixOne.DB.Helpers
{
    public static class Transpose
    {
        public static ProductViewModel ToViewModel(this Product product)
        {
            return new ProductViewModel
            {
                CategoryId = product.CategoryId,
                CategoryDescription = product.Category.Description,
                CategoryName = product.Category.Name,
                ProductDescription = product.Description,
                ProductId = product.Id,
                ProductImage = product.Image,
                ProductName = product.Name,
                ProductPrice = product.Price
            };
        }

        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<Product> products) => products.Select(ToViewModel).ToList();

        public static Product ToProduct(this Product p)
        {
            return new Product
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image
            };
        }
    }
}