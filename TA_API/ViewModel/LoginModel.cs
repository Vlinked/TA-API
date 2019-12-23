using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TA_API.ViewModel
{
    public class LoginModel
    {
        [Required]
        public string UserNameorEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
