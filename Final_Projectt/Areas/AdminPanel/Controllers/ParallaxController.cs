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
    public class ParallaxController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public ParallaxController(AppDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Parallaxs);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Parallax prl = await _context.Parallaxs.FindAsync(id);
            if (prl == null) return NotFound();
            return View(prl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Parallax prl)
        {
            Parallax parallaxdb = await _context.Parallaxs.FindAsync(id);

            if (parallaxdb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (ModelState["Title1"].ValidationState == ModelValidationState.Invalid
                || ModelState["Title2"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }


            if (prl.PhotoUpd != null)
            {
                if (!prl.PhotoUpd.IsImage())
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkil faylı seçin");
                    return View();
                }

                if (!prl.PhotoUpd.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await prl.PhotoUpd.CopyImages(_env.WebRootPath, "parallax");
                Utility.DeleteImgFromFolder(_env.WebRootPath, parallaxdb.Image);

                parallaxdb.Image = filename;
            }


            parallaxdb.Title1 = prl.Title1;
            parallaxdb.Title2 = prl.Title2;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
     
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Parallax prl = await _context.Parallaxs.FindAsync(id);
            if (prl == null) return NotFound();
            return View(prl);
        }
    }
}