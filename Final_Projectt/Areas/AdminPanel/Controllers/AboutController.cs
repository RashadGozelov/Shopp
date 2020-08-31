using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Extentions;
using Final_Projectt.Models;
using Final_Projectt.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Final_Projectt.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = Utility.AdminRole)]
    public class AboutController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public AboutController(AppDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Abouts);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            About about = await _context.Abouts.FindAsync(id);
            if (about == null) return NotFound();
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, About about)
        {
            About aboutdb = await _context.Abouts.FindAsync(id);

            if (aboutdb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (ModelState["Title"].ValidationState == ModelValidationState.Invalid
                || ModelState["Description"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }


            if (about.PhotoUpd != null)
            {
                if (!about.PhotoUpd.IsImage())
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkil faylı seçin");
                    return View();
                }

                if (!about.PhotoUpd.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await about.PhotoUpd.CopyImages(_env.WebRootPath, "about");
                Utility.DeleteImgFromFolder(_env.WebRootPath, aboutdb.Image);

                aboutdb.Image = filename;
            }


            aboutdb.Title = about.Title;
            aboutdb.Description = about.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            About about = await _context.Abouts.FindAsync(id);
            if (about == null) return NotFound();
            return View(about);
        }

    }
}