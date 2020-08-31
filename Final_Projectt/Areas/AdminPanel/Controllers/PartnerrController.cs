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
    public class PartnerrController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public PartnerrController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Partners);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Partner partner)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }

            if (!partner.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Şəkil faylı seçin");
                return View();
            }

            if (!partner.Photo.ImageSizeCheck(2))
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                return View();
            }

            string filename = await partner.Photo.CopyImages(_env.WebRootPath, "partnyor");
            partner.Image = filename;
            await _context.Partners.AddAsync(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Partner partner = await _context.Partners.FindAsync(id);
            if (partner == null) return NotFound();
            return View(partner);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Partner partner = await _context.Partners.FindAsync(id);
            Utility.DeleteImgFromFolder(_env.WebRootPath, partner.Image);
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Partner prt = await _context.Partners.FindAsync(id);
            if (prt == null) return NotFound();
            return View(prt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Partner prt)
        {
            Partner partnerdb = await _context.Partners.FindAsync(id);

            if (partnerdb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (prt.PhotoUpd != null)
            {
                if (!prt.PhotoUpd.IsImage())
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkil faylı seçin");
                    return View();
                }

                if (!prt.PhotoUpd.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await prt.PhotoUpd.CopyImages(_env.WebRootPath, "partnyor");
                Utility.DeleteImgFromFolder(_env.WebRootPath, partnerdb.Image);

                partnerdb.Image = filename;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Partner partner = await _context.Partners.FindAsync(id);
            if (partner == null) return NotFound();
            return View(partner);
        }

    }
}