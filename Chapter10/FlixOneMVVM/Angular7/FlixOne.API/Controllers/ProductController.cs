using System;
using System.Linq;
using FlixOne.API.Models;
using FlixOne.API.Persistence;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.API.Controllers
{
    /// <inheritdoc />
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        /// <inheritdoc />
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// Product Listing
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("productlist")]
        public IActionResult GetList()
        {
            return new OkObjectResult(_productRepository.GetAll().Select(ToProductvm).ToList());
        }
        /// <summary>
        /// Retrieve product for a specific product using productId
        /// </summary>
        /// <param name="productId">Unique Id of Product</param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/{productid}")]
        public IActionResult Get(string productId)
        {
            var productModel = _productRepository.GetBy(new Guid(productId));

            return new OkObjectResult(ToProductvm(productModel));
        }
        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productvm"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("addproduct")]
        public IActionResult Post([FromBody] ProductViewModel productvm)
        {
            if (productvm == null)
                return BadRequest();
            var productModel = ToProductModel(productvm);

            _productRepository.Add(productModel);

            return StatusCode(201, Json(true));
        }
        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="productid">Unique product Id</param>
        /// <param name="productvm">Product - is being updated</param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateproduct/{productid}")]
        public IActionResult Update(string productid, [FromBody] ProductViewModel productvm)
        {
            var productId = new Guid(productid);
            if (productvm == null || productvm.ProductId != productId)
                return BadRequest();

            var product = _productRepository.GetBy(productId);
            if (product == null)
                return NotFound();

            product.Name = productvm.ProductName;
            product.Description = productvm.ProductDescription;
            product.Price = productvm.ProductPrice;
            _productRepository.Update(product);
            return new NoContentResult();
        }
        /// <summary>
        /// Remove a specific product
        /// </summary>
        /// <param name="productid">Unique Product Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteproduct/{productid}")]
        public IActionResult Delete(string productid)
        {
            var productId = new Guid(productid);
            var product = _productRepository.GetBy(productId);
            if (product == null)
                return NotFound();

            _productRepository.Remove(productId);
            return new NoContentResult();
        }

        private Product ToProductModel(ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice
            };
        }

        private ProductViewModel ToProductvm(Product productModel)
        {
            return new ProductViewModel
            {
                CategoryId = productModel.CategoryId,
                CategoryDescription = productModel.Category.Description,
                CategoryName = productModel.Category.Name,
                ProductDescription = productModel.Description,
                ProductId = productModel.Id,
                ProductImage = productModel.Image,
                ProductName = productModel.Name,
                ProductPrice = productModel.Price
            };
        }
    }
}