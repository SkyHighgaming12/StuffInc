using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Warranty
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Warranty")]
        public string ImageURL { get; set; }
        [Display(Name = "Warranty Length")]
        public string Name { get; set; }
        [Display(Name = "Warranty Description")]
        public string Description { get; set; }

        //Relationshis

        public List<Product> Products { get; set; }
    }
}
