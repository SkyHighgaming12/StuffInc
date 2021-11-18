using StuffInc.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Shipping:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Shipping Logo")]
        [Required(ErrorMessage = "Logo Is Required")]
        public string ImageURL { get; set; }
        [Display(Name = "Shipping Type")]
        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 50 Characters")]
        public string Name { get; set; }
        [Display(Name = "Shipping Description")]
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }

        //relationships
        public List<Shipping_Product> Shipping_Products { get; set; }
    }
}
