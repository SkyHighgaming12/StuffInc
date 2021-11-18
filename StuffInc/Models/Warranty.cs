using StuffInc.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Warranty:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Warranty")]
        [Required(ErrorMessage = "Image Is Required")]
        public string ImageURL { get; set; }
        [Display(Name = "Warranty Length")]
        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 50 Characters")]
        public string Name { get; set; }
        [Display(Name = "Warranty Description")]
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }

        //Relationshis

        public List<Product> Products { get; set; }
    }
}
