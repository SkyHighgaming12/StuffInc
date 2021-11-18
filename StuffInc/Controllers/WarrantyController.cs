﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using StuffInc.Data.Services;
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
    }
}
