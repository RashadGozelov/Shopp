using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Marka
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Xananı boş buraxmayın"),StringLength(100)]

        public string Name { get; set; }

        public virtual ICollection<MarkaCategory> MarkaCategorys { get; set; }
    }
}
