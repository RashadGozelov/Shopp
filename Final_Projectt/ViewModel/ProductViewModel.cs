using Final_Projectt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public Category Category { get; set; }

        public MarkaCategory MarkaCategory { get; set; }

        public Marka Marka { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<ProductImage> ProductImages { get; set; }

        public IEnumerable<Marka> Markas { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<MarkaCategory> MarkaCategories { get; set; }

        public int CategoryId { get; set; }

        public int MarkaId { get; set; }
    }
}
