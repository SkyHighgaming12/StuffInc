using Microsoft.AspNetCore.Mvc;
using StuffInc.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }


        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
