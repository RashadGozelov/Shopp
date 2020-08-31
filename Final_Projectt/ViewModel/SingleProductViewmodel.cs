
using Final_Projectt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class SingleProductViewmodel
    {
       
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Category SingleCategory { get; set; }
        public IEnumerable<Marka> Markas { get; set; }
        public IEnumerable<MarkaCategory> MarkaCategorys { get; set; }
        public Product SingleProduct { get; set; }
    }
}
