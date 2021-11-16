using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly AppDbContext _context;

        public WarrantyController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allWarranties = await  _context.Warranties.ToListAsync();
            return View(allWarranties);
        }
    }
}
