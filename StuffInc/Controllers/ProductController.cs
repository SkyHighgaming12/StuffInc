using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _context.Products.Include(n => n.Supplier).OrderBy(n => n.Name).ToListAsync();
            return View(allProducts);
        }
    }
}
