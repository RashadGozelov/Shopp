using Final_Projectt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class HomeModel
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Parallax> Parallaxs { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categorys { get; set; }
        public IEnumerable<Marka> Markas { get; set; }
        public IEnumerable<MarkaCategory> MarkaCategorys { get; set; }
        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<About> Abouts { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public Category Category2 { get; set; }
        public List<Product> Gametime { get; set; }
    }
}
