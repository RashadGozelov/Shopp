using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Final_Projectt.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = Utility.AdminRole)]
    public class CategorieController : Controller
    {
        private AppDbContext _context;
        public CategorieController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categorys);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category ctg)
        {
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            
            await _context.Categorys.AddAsync(ctg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Category ctg = await _context.Categorys.FindAsync(id);
            if (ctg == null) return NotFound();
            return View(ctg);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Category ctg = await _context.Categorys.FindAsync(id);
            _context.Categorys.Remove(ctg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Category ctg = await _context.Categorys.FindAsync(id);
            if (ctg == null) return NotFound();
            return View(ctg);
        }

    }
}