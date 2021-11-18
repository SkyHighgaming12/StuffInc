﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //products/details/1

        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.SupplierId = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
            ViewBag.WarrantyId = new SelectList(productDropdownsData.Warrenties, "Id", "Name");
            ViewBag.ShippingId = new SelectList(productDropdownsData.Shippings, "Id", "Name");

            return View();
        }
    }
}
