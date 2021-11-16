using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Shipping_Product
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
    }
}
