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
    public class ProductController : Controller
    {
        private readonly IProductsService _service;

        public ProductController(IProductsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Supplier);
            return View(allProducts);
        }
    }
}
