using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data.ViewModels
{
    public class LoginVm
    {

        [Required(ErrorMessage = "Email Is Required")]
        [Display(Name = "EmailAddress")]
        public string EmailAddress { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
