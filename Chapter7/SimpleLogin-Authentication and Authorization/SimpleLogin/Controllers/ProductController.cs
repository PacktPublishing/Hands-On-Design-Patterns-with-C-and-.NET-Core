using System;
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
    }
}