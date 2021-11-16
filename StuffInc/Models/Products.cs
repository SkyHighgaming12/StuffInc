using StuffInc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Added { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
