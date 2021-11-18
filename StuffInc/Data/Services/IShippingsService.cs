using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public interface IShippingsService
    {
        Task<IEnumerable<Shipping>> GetAll();
        Shipping GetById(int id);
        void Add(Shipping shipping);
        Shipping Update(int id, Shipping newShipping);
        void Delete(int id);
    }
}
