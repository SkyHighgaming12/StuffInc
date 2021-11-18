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
        [Required(ErrorMessage = "Logo Url Is Required")]
        public string Logo { get; set; }
        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 50 Characters")]
        public string Name { get; set; }
        [Display(Name = "Supplier Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //Relationships

        public List<Product> Products { get; set; }
    }
}
