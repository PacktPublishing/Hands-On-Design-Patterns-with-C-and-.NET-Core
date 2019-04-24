using System;
using System.Collections.Generic;
using SimpleLogin.Models;

namespace Product_Test.Fake
{
    public class ProductData
    {
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var productVm = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryDescription = "Category Description",
                    CategoryName = "Category Name",
                    ProductDescription = "Product Description",
                    ProductId = Guid.NewGuid(),
                    ProductImage = "Image full path",
                    ProductName = "Product Name",
                    ProductPrice = 112M
                },
                new ProductViewModel
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryDescription = "Category Description-01",
                    CategoryName = "Category Name-01",
                    ProductDescription = "Product Description-01",
                    ProductId = Guid.NewGuid(),
                    ProductImage = "Image full path",
                    ProductName = "Product Name-01",
                    ProductPrice = 12M
                }
            };

            return productVm;
        }

        public IEnumerable<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product
                {
                    Category = new Category(),
                    CategoryId = Guid.NewGuid(),
                    Description = "Product Description-01",
                    Id = Guid.NewGuid(),
                    Image = "image full path",
                    Name = "Product Name-01",
                    Price = 12M
                },
                new Product
                {
                    Category = new Category(),
                    CategoryId = Guid.NewGuid(),
                    Description = "Product Description-02",
                    Id = Guid.NewGuid(),
                    Image = "image full path",
                    Name = "Product Name-02",
                    Price = 125M
                }
            };
        }
    }
}