using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }     

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        //public int Count { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

        public decimal Subtotal { get; set; }

    }
}
