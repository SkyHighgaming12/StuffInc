using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using StuffInc.Data.Services;
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
    }
}
