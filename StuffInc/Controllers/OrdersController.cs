using Microsoft.AspNetCore.Mvc;
using StuffInc.Data.Cart;
using StuffInc.Data.Services;
using StuffInc.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
        }


        public IActionResult ShoppingCart()
        {

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVm()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
