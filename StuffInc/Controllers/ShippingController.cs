using Microsoft.AspNetCore.Mvc;
using StuffInc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class ShippingController : Controller
    {
        private readonly AppDbContext _context;

        public ShippingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Shippings.ToList();
            return View(data);
        }
    }
}
