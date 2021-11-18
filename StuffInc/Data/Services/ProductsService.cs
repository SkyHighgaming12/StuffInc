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
        public ProductsService(AppDbContext context): base(context)
        {
               
        }
    }
}
