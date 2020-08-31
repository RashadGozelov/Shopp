using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
