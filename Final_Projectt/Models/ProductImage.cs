using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Zəhmət olmasa xananı boş buraxmayın"), StringLength(255)]

        public string Image { get; set; }

        public int ProductId { get; set; }

        public string Active { get; set; }

        public virtual Product Product { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Zəhmət olmasa şəkil seçin")]

        public List<IFormFile> Photo { get; set; }
        [NotMapped]

        public List<IFormFile> PhotoUpd { get; set; }
    }
}
