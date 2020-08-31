using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Final_Projectt.Controllers
{
    public class AboutController : Controller
    {
        private AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
    }
        public IActionResult Index()
        {
            HomeModel homeModel = new HomeModel
            {
                Abouts=_context.Abouts
            };
            return View(homeModel);
        }
    }
}