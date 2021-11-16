﻿using System;
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

        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }

        //Relationshis

        public List<Product> Products { get; set; }
    }
}
