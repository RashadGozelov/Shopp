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
    public class LogoController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public LogoController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Bios);
        }

   
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Bio bio = await _context.Bios.FindAsync(id);
            if (bio == null) return NotFound();
            return View(bio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Bio bio)
        {
            Bio biodb = await _context.Bios.FindAsync(id);

            if (biodb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (ModelState["Facebook"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Twitter"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Instagram"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Youtube"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }


            if (bio.PhotoUpd != null)
            {
                if (!bio.PhotoUpd.IsImage())
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkil faylı seçin");
                    return View();
                }

                if (!bio.PhotoUpd.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("PhotoUpd", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await bio.PhotoUpd.CopyImages(_env.WebRootPath, "logo");
                Utility.DeleteImgFromFolder(_env.WebRootPath, biodb.Image);

                biodb.Image = filename;
            }


            biodb.Facebook = bio.Facebook;
            biodb.Twitter = bio.Twitter;
            biodb.Instagram = bio.Instagram;
            biodb.Youtube = bio.Youtube;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Bio bio = await _context.Bios.FindAsync(id);
            if (bio == null) return NotFound();
            return View(bio);
        }

    }
}