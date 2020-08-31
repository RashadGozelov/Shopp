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
    public class ContactController : Controller
    {
        private AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contacts);
        }
      
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Contact cnt = await _context.Contacts.FindAsync(id);
            if (cnt == null) return NotFound();
            return View(cnt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Contact cnt)
        {
            Contact contactdb = await _context.Contacts.FindAsync(id);

            if (contactdb == null)
            {

                return RedirectToAction(nameof(Index));

            }

            if (ModelState["Address"].ValidationState == ModelValidationState.Invalid
                || ModelState["Mail"].ValidationState == ModelValidationState.Invalid
                || ModelState["Phone"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            
            contactdb.Address = cnt.Address;
            contactdb.Mail = cnt.Mail;
            contactdb.Phone = cnt.Phone;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}