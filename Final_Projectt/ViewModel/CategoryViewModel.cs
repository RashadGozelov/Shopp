using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public IEnumerable<SubCategoryViewModel> Markas { get; set; }
    }

    public class SubCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
