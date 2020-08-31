using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Partner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxmayın"), StringLength(250)]
        public string Image { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Şəkil tələb olunur")]
        public IFormFile Photo { get; set; }
        [NotMapped]

        public IFormFile PhotoUpd { get; set; }
    }
}
