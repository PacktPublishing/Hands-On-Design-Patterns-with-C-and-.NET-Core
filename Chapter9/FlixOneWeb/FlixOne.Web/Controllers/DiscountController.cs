using System;
using FlixOne.Web.Common;
using FlixOne.Web.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IInventoryRepositry _repositry;

        public DiscountController(IInventoryRepositry inventoryRepositry)
        {
            _repositry = inventoryRepositry;
        }

        public IActionResult Index()
        {
            return View(_repositry.GetDiscounts().ToDiscountViewModel());
        }

        public IActionResult Details(Guid id)
        {
            return View("Index", _repositry.GetDiscountBy(id).ToDiscountViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}