using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.Utilities;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Final_Projectt.Areas.AdminPanel.Controllers
{
    
    [Area("AdminPanel")]
    [Authorize(Roles = Utility.AdminRole)]
    public class MarkaController : Controller
    {
        private AppDbContext _context;
        public MarkaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Markas);
        }

        public IActionResult Create()
        {
            //List<Product> Products1 = _context.Products
            //   .Include(x => x.MarkaCategory)
            //   .Include(i => i.MarkaCategory.Category)
            // .Where(pr => (categoryid == null || pr.MarkaCategory.CategoryId == categoryid)).OrderByDescending(m => m.Id).ToList();

            //HomeModel homeModel = new HomeModel
            //{
            //    Products = Products1,
            //    Categorys=_context.Categorys
            //};
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marka mrk)
        {
           
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }

            await _context.Markas.AddAsync(mrk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Marka ctg = await _context.Markas.FindAsync(id);
            if (ctg == null) return NotFound();
            return View(ctg);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Marka ctg = await _context.Markas.FindAsync(id);
            _context.Markas.Remove(ctg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Marka ctg = await _context.Markas.FindAsync(id);
            if (ctg == null) return NotFound();
            return View(ctg);
        }
    }
}