using System;
using FlixOne.Web.Common;
using FlixOne.Web.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IInventoryRepository _repository;

        public DiscountController(IInventoryRepository inventoryRepository)
        {
            _repository = inventoryRepository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetDiscounts().ToDiscountViewModel());
        }

        public IActionResult Details(Guid id)
        {
            return View("Index", _repository.GetDiscountBy(id).ToDiscountViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}