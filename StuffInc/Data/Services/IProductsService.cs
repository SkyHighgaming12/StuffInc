using StuffInc.Data.Base;
using StuffInc.Data.ViewModels;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public interface IProductsService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductsDropdownsVm> GetNewMovieDropdownsValues();
    }
}
