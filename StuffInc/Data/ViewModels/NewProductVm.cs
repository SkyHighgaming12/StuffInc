using StuffInc.Data;
using StuffInc.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class NewProductVm
    {
        [Display(Description = "Product Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 50 Characters")]
        public string Name { get; set; }
        [Display(Description = "Product Image")]
        [Required(ErrorMessage = "ImageURL is Required")]
        public string ImageURL { get; set; }
        [Display(Description = "Product Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [Display(Description = "Product Price in $")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [Display(Description = "Product Added on")]
        public DateTime Added { get; set; }
        [Display(Description = "Select a Category")]
        [Required(ErrorMessage = "Category is Required")]
        public ProductCategory ProductCategory { get; set; }

        //relationships
        [Display(Description = "Select Shipping type(s)")]
        [Required(ErrorMessage = "Shipping type is Required")]
        public List<int> ShippingIds { get; set; }
        [Display(Description = "Product Supplier")]
        [Required(ErrorMessage = "Supplier is Required")]
        public int SupplierId { get; set; }
        [Display(Description = "Product Warranty")]
        [Required(ErrorMessage = "Warranty is Required")]
        public int WarrantyId { get; set; }
        
    }
}
