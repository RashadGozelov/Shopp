using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Display(Name ="E-poçt")]
        [Required(ErrorMessage ="Xananı boş buraxmayın"),EmailAddress(ErrorMessage = "E-poçt ünvanı düzgün yazın")]
        public string Email { get; set; }
    }
}
