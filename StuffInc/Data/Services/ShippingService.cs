using Microsoft.EntityFrameworkCore;
using StuffInc.Data.Base;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public class ShippingService : EntityBaseRepository<Shipping>, IShippingsService
    {
      

        public ShippingService(AppDbContext context) : base(context){}
       
    }
}
