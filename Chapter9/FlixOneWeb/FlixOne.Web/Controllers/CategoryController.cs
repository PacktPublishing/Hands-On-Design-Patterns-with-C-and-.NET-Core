using System;
using FlixOne.Web.Models;
using FlixOne.Web.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers
{
    public class CategoryController: Controller
    {
        private readonly IInventoryRepositry _inventoryRepositry;

        public CategoryController(IInventoryRepositry inventoryRepositry) => _inventoryRepositry = inventoryRepositry;

        public IActionResult Index() => View(_inventoryRepositry.GetCategories());
        
        public IActionResult Details(Guid id) => View(_inventoryRepositry.GetCategory(id));

        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                _inventoryRepositry.AddCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(Guid id) => View(_inventoryRepositry.GetCategory(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [FromBody]Category category)
        {
            try
            {
                _inventoryRepositry.UpdateCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(Guid id) => View(_inventoryRepositry.GetCategory(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, [FromBody] Category category)
        {
            try
            {
                _inventoryRepositry.RemoveCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
