using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Final_Projectt.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}