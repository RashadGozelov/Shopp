using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Projectt.Controllers
{
    public class HomeController : Controller
    {
        private const byte _take = 9;
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> Gametime = _context.Products
                                    .Include(p => p.MarkaCategory)
                                    .Include(p => p.MarkaCategory.Category)
                                    .Where(p => p.MarkaCategory.Category.Name.ToLower() == "Oyun konsolu".ToLower())
                                    .Take(2).ToList();
                                    

            HomeModel homeModel = new HomeModel
            {
                Sliders = _context.Sliders,
                Parallaxs=_context.Parallaxs,
                Brands=_context.Brands,
                ProductImages = _context.ProductImages,
                Products = _context.Products.Include(p => p.ProductImages).Include(a=>a.MarkaCategory.Category),
                Categorys = _context.Categorys.Include(o => o.MarkaCategorys),
                Markas =_context.Markas,
                MarkaCategorys =_context.MarkaCategorys,
                Gametime=Gametime
                
            };
            return View(homeModel);
        }
    
        //public IActionResult Searchh(string str)
        //{
        //    var model = _context.Products.Where(s => s.Name.Contains(str)).Take(7);
        //    return PartialView("_searchPartial", model);
        //}
        

      
        public IActionResult SearchProduct(string str)
        {
            HeaderViewModel headerViewModel = new HeaderViewModel
            {
                Products=_context.Products.Where(p=>p.Name.Contains(str)).Take(3)
             
            };

            return PartialView("_searchView", headerViewModel);
        }

       
        public IActionResult GetProductByCat(int id)
        {
            return Content("Hello");
        }

    }
}