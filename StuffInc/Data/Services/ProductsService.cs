using Microsoft.EntityFrameworkCore;
using StuffInc.Data.Base;
using StuffInc.Data.ViewModels;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVm data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                SupplierId = data.SupplierId,
                WarrantyId = data.WarrantyId,
                Added = data.Added,
                ImageURL = data.ImageURL,
                ProductCategory = data.ProductCategory
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();


            foreach (var shippingId in data.ShippingIds)
            {
                var newShippingProduct = new Shipping_Product()
                {
                    ProductId = newProduct.Id,
                    ShippingId = shippingId
                };
                await _context.Shipping_Products.AddAsync(newShippingProduct);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewProductsDropdownsVm> GetNewMovieDropdownsValues()
        {
            var response = new NewProductsDropdownsVm()
            {
                Shippings = await _context.Shippings.OrderBy(n => n.Name).ToListAsync(),
                Warrenties = await _context.Warranties.OrderBy(n => n.Name).ToListAsync(),
                Suppliers = await _context.Suppliers.OrderBy(n => n.Name).ToListAsync()
            };



            return response;
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
