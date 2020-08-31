using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Parallax
    {
        public int Id { get; set; }
        [Required,StringLength(255, ErrorMessage = "Şəkilin uzunluğu 255 hərfdən artıq ola bilməz ")]

        public string Image { get; set; }
        [Required(ErrorMessage = "Başlıq tələb olunur"), StringLength(100,ErrorMessage = "Başlıq 100 hərfdən artıq ola bilməz ")]

        public string Title1 { get; set; }
        [Required(ErrorMessage = "Alt yazı tələb olunur"), StringLength(150, ErrorMessage = "Başlıq 150 hərfdən artıq ola bilməz ")]

        public string Title2 { get; set; }
        [NotMapped]

        public IFormFile PhotoUpd { get; set; }
    }
}
