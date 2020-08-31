using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Final_Projectt.Controllers
{
    public class ShopController : Controller
    {
        private const byte _take = 9;
        public int skip { get; set; }
        private AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? markaid, int? categoryid)
        {
            List<Product> Products1 = _context.Products
                //.Include(p=>p.ProductImages)
                .Include(x => x.MarkaCategory)
                .Include(y => y.MarkaCategory.Marka)
                .Include(i => i.MarkaCategory.Category)
              .Include(m => m.ProductImages)
              .Where(pr => (categoryid == null || pr.MarkaCategory.CategoryId == categoryid) &&
                (markaid == null || pr.MarkaCategory.MarkaId == markaid)).OrderByDescending(m => m.Id).Take(_take).ToList();

            HomeModel homeModel = new HomeModel
            {
                Categorys = _context.Categorys.Include(o => o.MarkaCategorys),
                Products = Products1,
                ProductImages = _context.ProductImages,
                Markas = _context.Markas,
                MarkaCategorys = _context.MarkaCategorys,
                Category2 = _context.Categorys.Include(a => a.MarkaCategorys).FirstOrDefault(c => c.Id == categoryid)
            };
            return View(homeModel);

        }

        public IActionResult Search(SearchModel search)
        {
            try
            {
                var categories= JsonConvert.DeserializeObject<List<int>>(search.Categories);
                var markas= JsonConvert.DeserializeObject<List<int>>(search.Markas);
                var products = _context.Products
                    .Include(x => x.MarkaCategory)
                    .Include(x => x.MarkaCategory.Marka)
                    .Include(x => x.MarkaCategory.Category)
                    .Include(x => x.ProductImages)
                    .Where(x =>categories.Count()==0?true: categories.Contains(x.MarkaCategory.CategoryId))
                    .Where(x =>markas.Count()==0?true : markas.Contains(x.MarkaCategory.MarkaId)).ToList();
                return PartialView("~/Views/Shared/_searchPartial.cshtml", products);
            }
            catch (Exception ex)
            {
                return PartialView(ex);
            }
        }
        //Search
        public IActionResult SearchProduct(string str)
        {
            HeaderViewModel headerViewModel = new HeaderViewModel
            {
                Products = _context.Products.Where(p => p.Name.Contains(str)).Take(3)

            };

            return PartialView("_searchView", headerViewModel);
        }
    }
}