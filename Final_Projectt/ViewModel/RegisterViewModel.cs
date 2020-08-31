using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Zəhmət olmasa xananı boş buraxmayın")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"),EmailAddress(ErrorMessage = "E-poçt ünvanı düzgün yazın"),DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        //[RegularExpression(@"[a-z]{3,4}", ErrorMessage = "Şifrə 8 simvoldan ibarət olmalıdır")]
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"), DataType(DataType.Password)]
       
        public string Password { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"), Compare(nameof(Password),ErrorMessage ="Şifrəni düzgün yazın"),DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}
