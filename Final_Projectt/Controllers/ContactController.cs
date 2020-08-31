using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Final_Projectt.Controllers
{
    public class ContactController : Controller
    {
        private AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            ViewData["SomeList"] = _context.Contacts;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Message(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contactViewModel);
            }
            try
            {
                var body = "<p>Email From: {0} ({2})</p><p>Message:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("rashad.gozelov@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("resad.gozelov12345@gmail.com");  // replace with valid value
                message.Subject = contactViewModel.Subject;
                message.Body = string.Format(body, contactViewModel.Name, contactViewModel.Surname, contactViewModel.Email, contactViewModel.Message);
                message.IsBodyHtml = true;

              
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "resad.gozelov12345@gmail.com",  // replace with valid value
                        Password = "rashad765."  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    ViewBag.Success = "Mesajınız göndərildi";
                    smtp.Send(message);
                 
                }
               
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Mesajınız göndərilmedi";
                return View();
            }
           

        }
    }
}