using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleLogin.Common;
using SimpleLogin.Models;
using SimpleLogin.Persistance;

namespace SimpleLogin.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly IInventoryRepositry _inventoryRepositry;

        public ProductController(IInventoryRepositry inventoryRepositry) => _inventoryRepositry = inventoryRepositry;

        public IActionResult Index() => View(_inventoryRepositry.GetProducts().ToProductvm());

        public IActionResult Details(Guid id) => View(_inventoryRepositry.GetProduct(id).ToProductvm());

        public IActionResult Create() => View();
        [HttpGet]
        [Route("productlist")]
        public IActionResult GetList() => new OkObjectResult(_inventoryRepositry.GetAll().Select(ToProductvm).ToList());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Product product)
        {
            try
            {
                _inventoryRepositry.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(Guid id) => View(_inventoryRepositry.GetProduct(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id, Name,Description,Image,Price,CategoryId")] Product product)
        {
            try
            {
                _inventoryRepositry.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(Guid id) => View(_inventoryRepositry.GetProduct(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, [Bind("Id, Name,Description,Image,Price,CategoryId")] Product product)
        {
            try
            {
                _inventoryRepositry.RemoveProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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