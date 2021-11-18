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


        // supplier/details/1
        public async Task<IActionResult> Details(int id)
        {
            var supplierDetails = await _service.GetByIdAsync(id);
            if (supplierDetails == null) return View("NotFound");

            return View(supplierDetails);
        }

        // supplier/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var warrantyDetails = await _service.GetByIdAsync(id);
            if (warrantyDetails == null) return View("NotFound");
            return View(warrantyDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Supplier supplier)
        {

            if (!ModelState.IsValid) return View(supplier);

            if (id == supplier.Id)
            {
                await _service.UpdateAsync(id, supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }



        // warranty/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var supplierDetails = await _service.GetByIdAsync(id);
            if (supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warrantyDetails = await _service.GetByIdAsync(id);
            if (warrantyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }

    
}
