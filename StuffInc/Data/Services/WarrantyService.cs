using StuffInc.Data.Base;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public class WarrantyService: EntityBaseRepository<Warranty>, IWarrantyService
    {
        public WarrantyService(AppDbContext context): base(context)
        {

        }
    }
}
