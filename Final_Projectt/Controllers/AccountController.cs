using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;     // Send email
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.Utilities;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Authorization;     //ForgotPassword 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Final_Projectt.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailsender;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailsender = emailSender;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            AppUser newUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerViewModel);
            }

            //SMTP yazacam
            string token =await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);
            await _emailsender.SendEmailAsync(registerViewModel.Email, "E-poçtunuzu təsdiqləyin",
                $"Bu linki izləyərək hesabınızı təsdiqləyin" +
                $"<a href='{HtmlEncoder.Default.Encode($"https://localhost:44312/Account/ConfirmEmail?token={codeEncoded}&userId={newUser.Id}")}'>" +
                $"  Link" +
                $"</a>"
                );

            await _userManager.AddToRoleAsync(newUser, Utility.Roles.Member.ToString());
            await _signInManager.SignInAsync(newUser, true);
            return View("VerifyEmail");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            var user =await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var codeDecodedBytes = WebEncoders.Base64UrlDecode(token);
                var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
                IdentityResult result = await _userManager.ConfirmEmailAsync(user, codeDecoded);
                if (result.Succeeded)
                {
                    
                    return View();
                }
            }
            return View("FailedConfirmation");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "E-poçt ünvani və şifrə səhvdir");
                return View(loginViewModel);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Sizin e-poçtunuz təsdiq olunmayıb.Zəhmət olmasa,e-poçtunuzu yoxlayın.");
                return View(loginViewModel);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "E-poçt ünvani və şifrə səhvdir");
                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Accountt()
        {
            return View();
        }

        public async Task RoleSeeder()
        {
            if (!await _roleManager.RoleExistsAsync(Utility.Roles.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Utility.Roles.Admin.ToString()));
            }
            if (!await _roleManager.RoleExistsAsync(Utility.Roles.Member.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Utility.Roles.Member.ToString()));
            }
          
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            var user= await _userManager.FindByEmailAsync(forgotPassword.Email);

            if (user == null)
            {
                //ViewBag.Error = "Daxil etdiyiniz e-poçt mövcud deyil";
                ModelState.AddModelError("", "Daxil etdiyiniz e-poçt mövcud deyil");
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);
            await _emailsender.SendEmailAsync(forgotPassword.Email, "Şifrənizi yeniləyin",
                $"Bu linki izləyərək şifrənizi yeniləyin" +
                $"<a href='{HtmlEncoder.Default.Encode($"https://localhost:44312/Account/ResetPassword?token={codeEncoded}&userId={user.Id}")}'>" +
                $"  Link" +
                $"</a>"
                );

            return View("VerifyEmail");
        }

        public IActionResult ResetPassword(string token,string userId)
        {
            var model = new UserResetPasswordModel
            {
                Token = token,
                UserId = userId
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(UserResetPasswordModel userReset)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Yeni şifrə düzgün deyil");
                return View();
            }

            var user = await _userManager.FindByIdAsync(userReset.UserId);
            if (user==null)
            {
                ModelState.AddModelError("", "İstifadəçi tapılmadı");
                return View();
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(userReset.Token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await _userManager.ResetPasswordAsync(user, codeDecoded, userReset.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(userReset);
            }
            return RedirectToAction("Login");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    var MyUser = _context.Users.Where(x => x.Email == model.Email).FirstOrDefault();
        //    if (MyUser == null)
        //    {
        //        return BadRequest();
        //    }
        //    string mypass = Guid.NewGuid().ToString();
        //    string donedpass = mypass.Substring(0, 6);

        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(model.Email);
        //    mail.From = new MailAddress(model.Email);


        //    mail.Body = $"<a href='https://localhost:44366/Account/Login' class='btn btn-primary'> Yeni Parolunuz</a>  <strong> {donedpass.ToString()} </strong> ";

        //    mail.Subject = "Yeni Sifreni Daxil Edin";

        //    mail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        //    smtp.Credentials = new System.Net.NetworkCredential
        //         ("emailini yazzzzzzz", "emailinin sifresinni yazzzzz"); // ***use valid credentials***
        //    smtp.Port = 587;

        //    //Or your Smtp Email ID and Password
        //    smtp.EnableSsl = true;
        //    smtp.Send(mail);

        //    MyUser.PasswordHash = _userManager.PasswordHasher.HashPassword(MyUser, donedpass);

        //    var result = await _userManager.UpdateAsync(MyUser);
        //    if (!result.Succeeded)
        //    {
        //        return Content("Parol deyisdirilmedi");
        //    }

        //    return Content("Deyisdirildi");
        //}

       

    }
}
