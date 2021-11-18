using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.ViewModels
{
    public class NewProductsDropdownsVm
    {
        public NewProductsDropdownsVm()
        {
            Warrenties = new List<Warranty>();
            Shippings = new List<Shipping>();
            Suppliers = new List<Supplier>();
        }

        public List<Warranty> Warrenties { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Shipping> Shippings { get; set; }
    }
}
