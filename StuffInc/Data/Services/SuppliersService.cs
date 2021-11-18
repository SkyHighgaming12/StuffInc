using StuffInc.Data.Base;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public class SuppliersService:EntityBaseRepository<Supplier>, ISuppliersService
    {

        public SuppliersService(AppDbContext context) :base(context)
        {

        }
    }
}
