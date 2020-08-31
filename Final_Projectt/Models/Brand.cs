using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required, StringLength(255, ErrorMessage = "Şəkilin uzunluğu 255 hərfdən artıq ola bilməz ")]

        public string Image { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Şəkil tələb olunur")]

        public IFormFile Photo { get; set; }
        [NotMapped]

        public IFormFile PhotoUpd { get; set; }
    }
}
