using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public interface IShippingsService
    {
        Task<IEnumerable<Shipping>> GetAllAsync();
        Task<Shipping> GetByIdAsync(int id);
        Task AddAsync(Shipping shipping);
        Task<Shipping> UpdateAsync(int id, Shipping newShipping);
        Task DeleteAsync(int id);
    }
}
