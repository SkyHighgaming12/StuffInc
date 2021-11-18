using StuffInc.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Supplier: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Supplier Logo")]
        public string Logo { get; set; }
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        [Display(Name = "Supplier Description")]
        public string Description { get; set; }

        //Relationships

        public List<Product> Products { get; set; }
    }
}
