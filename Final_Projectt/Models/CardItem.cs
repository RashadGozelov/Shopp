using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class CardItem
    {
        //public Product Product { get; set; }
        //public int Count { get; set; }
        //public decimal Subtotal { get; set; }

        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int? ProductDiscount { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}
