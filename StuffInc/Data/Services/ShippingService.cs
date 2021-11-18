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
        public void Add(Shipping shipping)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shipping>> GetAll()
        {
            var result = await _context.Shippings.ToListAsync();
            return result;
        }

        public Shipping GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Shipping Update(int id, Shipping newShipping)
        {
            throw new NotImplementedException();
        }
    }
}
