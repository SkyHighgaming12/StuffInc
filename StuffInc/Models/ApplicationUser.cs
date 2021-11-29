﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full Name")]
        public string Name { get; set; }
    }
}
