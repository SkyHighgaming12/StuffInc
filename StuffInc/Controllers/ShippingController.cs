using StuffInc.Data;
using StuffInc.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingsService _service;

        public ShippingController(IShippingsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        //shipping/create
        public IActionResult Create()
        {
            return View();
        }
    }
}
