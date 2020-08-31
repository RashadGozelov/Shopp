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
    public class BrandCarousellController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public BrandCarousellController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }

            if (!brand.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Şəkil faylı seçin");
                return View();
            }

            if (!brand.Photo.ImageSizeCheck(2))
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                return View();
            }

            string filename = await brand.Photo.CopyImages(_env.WebRootPath, "brand");
            brand.Image = filename;
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Brand brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Brand brand = await _context.Brands.FindAsync(id);
            Utility.DeleteImgFromFolder(_env.WebRootPath, brand.Image);
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Brand brd = await _context.Brands.FindAsync(id);
            if (brd == null) return NotFound();
            return View(brd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brd)
        {
            Brand branddb = await _context.Brands.FindAsync(id);

            if (branddb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (brd.PhotoUpd != null)
            {
                if (!brd.PhotoUpd.IsImage())
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkil faylı seçin");
                    return View();
                }

                if (!brd.PhotoUpd.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await brd.PhotoUpd.CopyImages(_env.WebRootPath, "brand");
                Utility.DeleteImgFromFolder(_env.WebRootPath, branddb.Image);

                branddb.Image = filename;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Brand brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }

    }
}