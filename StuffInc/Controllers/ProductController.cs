using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StuffInc.Data;
using StuffInc.Data.Services;
using StuffInc.Data.Static;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductsService _service;

        public ProductController(IProductsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Supplier);
            return View(allProducts.OrderBy(n => n.Name));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Supplier);

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.Searchs = searchString;
                var filteredResult = allProducts.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower()) || n.ProductCategory.ToString().ToLower().Contains(searchString.ToLower()) || n.Supplier.Name.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }
            
            return View("Index", allProducts);
        }
        //products/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.SupplierId = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
            ViewBag.WarrantyId = new SelectList(productDropdownsData.Warrenties, "Id", "Name");
            ViewBag.ShippingId = new SelectList(productDropdownsData.Shippings, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVm product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.SupplierId = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
                ViewBag.WarrantyId = new SelectList(productDropdownsData.Warrenties, "Id", "Name");
                ViewBag.ShippingId = new SelectList(productDropdownsData.Shippings, "Id", "Name");
                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> Edit(int id)
        {

            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVm()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Price = productDetails.Price,
                Description = productDetails.Description,
                ImageURL = productDetails.ImageURL,
                ProductCategory = productDetails.ProductCategory,
                SupplierId = productDetails.SupplierId,
                WarrantyId = productDetails.WarrantyId,
                ShippingIds = productDetails.Shipping_Products.Select(n => n.ShippingId).ToList()

            };

            var productDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.SupplierId = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
            ViewBag.WarrantyId = new SelectList(productDropdownsData.Warrenties, "Id", "Name");
            ViewBag.ShippingId = new SelectList(productDropdownsData.Shippings, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVm product)
        {


            if (id != product.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.SupplierId = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
                ViewBag.WarrantyId = new SelectList(productDropdownsData.Warrenties, "Id", "Name");
                ViewBag.ShippingId = new SelectList(productDropdownsData.Shippings, "Id", "Name");
                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int id)
        {

            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVm()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Price = productDetails.Price,
                Description = productDetails.Description,
                ImageURL = productDetails.ImageURL,
                ProductCategory = productDetails.ProductCategory,
                SupplierId = productDetails.SupplierId,
                WarrantyId = productDetails.WarrantyId,
                ShippingIds = productDetails.Shipping_Products.Select(n => n.ShippingId).ToList()

            };

            var productDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.SupplierId = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
            ViewBag.WarrantyId = new SelectList(productDropdownsData.Warrenties, "Id", "Name");
            ViewBag.ShippingId = new SelectList(productDropdownsData.Shippings, "Id", "Name");

            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleeteConfirmed(int id)
        {

            await _service.DeleteAsync(id);
            
            return RedirectToAction(nameof(Index));

        }
    }
}
