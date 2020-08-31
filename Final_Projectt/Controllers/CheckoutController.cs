using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.Models;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Projectt.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}