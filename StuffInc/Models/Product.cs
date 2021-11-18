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
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Added { get; set; }
        public ProductCategory ProductCategory { get; set; }

        //relationships
        public List<Shipping_Product> Shipping_Products { get; set; }

        //supplier
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        //Warrenty
        public int WarrantyId { get; set; }
        [ForeignKey("WarrantyId")]
        public Warranty Warranty { get; set; }
    }
}
