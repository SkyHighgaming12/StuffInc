using Microsoft.EntityFrameworkCore;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public class ShippingService : IShippingsService
    {
        private readonly AppDbContext _context;

        public ShippingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Shipping shipping)
        {
            await _context.Shippings.AddAsync(shipping);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Shippings.FirstOrDefaultAsync(n => n.Id == id);
            _context.Shippings.Remove(result);
            await _context.SaveChangesAsync();
        }

        

        public async Task<Shipping> UpdateAsync(int id, Shipping newShipping)
        {
            _context.Update(newShipping);
            await _context.SaveChangesAsync();
            return newShipping;
        }
    }
}
