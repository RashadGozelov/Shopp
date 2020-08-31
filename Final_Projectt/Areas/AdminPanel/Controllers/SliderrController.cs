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
    public class SliderrController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public SliderrController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (ModelState["Title1"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Title2"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Şəkil faylı seçin");
                return View();
            }

            if (!slider.Photo.ImageSizeCheck(2))
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                return View();
            }

            string filename = await slider.Photo.CopyImages(_env.WebRootPath, "slider");
            slider.Image = filename;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            Utility.DeleteImgFromFolder(_env.WebRootPath, slider.Image);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider sld = await _context.Sliders.FindAsync(id);
            if (sld == null) return NotFound();
            return View(sld);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider sld)
        {
         
            Slider sliderdb = await _context.Sliders.FindAsync(id);

            if (sliderdb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (ModelState["Title1"].ValidationState == ModelValidationState.Invalid
                || ModelState["Title2"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }


            if (sld.PhotoUpd != null)
            {
                if (!sld.PhotoUpd.IsImage())
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkil faylı seçin");
                    return View();
                }

                if (!sld.PhotoUpd.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await sld.PhotoUpd.CopyImages(_env.WebRootPath, "slider");
                Utility.DeleteImgFromFolder(_env.WebRootPath, sliderdb.Image);

                sliderdb.Image = filename;
            }


            sliderdb.Title1 = sld.Title1;
            sliderdb.Title2 = sld.Title2;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
    }
}