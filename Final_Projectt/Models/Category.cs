using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kateqoriya tələb olunur"), StringLength(100, ErrorMessage = "Kateqoriya 100 hərfdən artıq ola bilməz ")]

        public string Name { get; set; }

        public virtual ICollection<MarkaCategory> MarkaCategorys { get; set; }
    }
}
