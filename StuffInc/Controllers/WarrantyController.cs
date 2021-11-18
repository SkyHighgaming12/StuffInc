using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using StuffInc.Data.Services;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly IWarrantyService _service;

        public WarrantyController(IWarrantyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allWarranties = await _service.GetAllAsync();
            return View(allWarranties);
        }

        // warranty/details/1
        public async Task<IActionResult> Details(int id)
        {
            var warrantyDetails = await _service.GetByIdAsync(id);
            if (warrantyDetails == null) return View("NotFound");

            return View(warrantyDetails);
        }


        // warranty/create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageURL,Name,Description")]Warranty warranty)
        {
            if (!ModelState.IsValid) return View(warranty);
            await _service.AddAsync(warranty);
            return RedirectToAction(nameof(Index));
        }
    }
}
