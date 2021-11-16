using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Shipping
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Shipping Logo")]
        public string ImageURL { get; set; }
        [Display(Name = "Shipping Type")]
        public string Name { get; set; }
        [Display(Name = "Shipping Description")]
        public string Description { get; set; }

        //relationships
        public List<Shipping_Product> Shipping_Products { get; set; }
    }
}
