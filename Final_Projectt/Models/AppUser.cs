using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
