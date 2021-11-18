using Microsoft.EntityFrameworkCore;
using StuffInc.Data.Base;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public class ProductsService:EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Supplier)
                .Include(w => w.Warranty)
                .Include(sp => sp.Shipping_Products).ThenInclude(s => s.Shipping)
                .FirstOrDefaultAsync(n => n.Id == id);
            return productDetails;
        }
    }
}
