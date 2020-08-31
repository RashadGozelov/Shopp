using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Xananı boş buraxmayın"), EmailAddress(ErrorMessage = "E-poçt ünvanı düzgün yazın"), DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxmayın"), DataType(DataType.Password)]

        public string Password { get; set; }

        public bool RememberMe { get; set; }
       
    }
}
