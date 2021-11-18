using StuffInc.Models;
using StuffInc.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISuppliersService _service;

        public SupplierController(ISuppliersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSuppliers = await _service.GetAllAsync();
            return View(allSuppliers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Supplier supplier)
        {
            if (!ModelState.IsValid) return View(supplier);
            await _service.AddAsync(supplier);
            return RedirectToAction(nameof(Index));
        }
    }

    
}
