using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Bio
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Zəhmət olmasa şəkil əlavə edin"),StringLength(255,ErrorMessage = "Yazı 255 hərfdən artıq ola bilməz")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"), StringLength(255, ErrorMessage = "Yazı 255 hərfdən artıq ola bilməz")]
        public string Facebook { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"), StringLength(255, ErrorMessage = "Yazı 255 hərfdən artıq ola bilməz")]
        public string Twitter { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"), StringLength(255, ErrorMessage = "Yazı 255 hərfdən artıq ola bilməz")]
        public string Instagram { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa xananı boş buraxmayın"), StringLength(255, ErrorMessage = "Yazı 255 hərfdən artıq ola bilməz")]
        public string Youtube { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Şəkil tələb olunur")]

        public IFormFile Photo { get; set; }
        [NotMapped]

        public IFormFile PhotoUpd { get; set; }
    }
}
