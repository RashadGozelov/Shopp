using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxma"), StringLength(250)]
        public string Image { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxma"), StringLength(80, ErrorMessage = "Simvolun uzunluğu 80dən artıq ola bilməz")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxma"), StringLength(1000, ErrorMessage = "Simvolun uzunluğu 1000dən artıq ola bilməz")]

        public string Description { get; set; }
        [NotMapped]

        public IFormFile PhotoUpd { get; set; }
    }
}
