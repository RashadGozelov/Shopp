using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"),EmailAddress(ErrorMessage = "E-poçt ünvanı düzgün yazın"), DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın")]

        public string Subject { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın")]

        public string Message { get; set; }
    }
}
