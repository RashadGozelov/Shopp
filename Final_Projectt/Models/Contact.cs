using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxma"), StringLength(400, ErrorMessage = "Simvolun uzunluğu 400dən artıq ola bilməz")]

        public string Address { get; set; }
        [Required(ErrorMessage ="Xananı boş buraxma"), StringLength(150, ErrorMessage = "Simvolun uzunluğu 150dən artıq ola bilməz")]

        public string Mail { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxma"), StringLength(100, ErrorMessage = "Simvolun uzunluğu 100dən artıq ola bilməz")]

        public string Phone { get; set; }
    }
}
