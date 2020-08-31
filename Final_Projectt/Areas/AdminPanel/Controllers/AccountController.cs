using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.Utilities;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Projectt.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class AccountController : Controller
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public RoleManager<IdentityRole> _roleManager;
        public AccountController(AppDbContext context,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Utility.AdminRole)]
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

            await _userManager.AddToRoleAsync(newUser, Utility.Roles.Admin.ToString());
            await _signInManager.SignInAsync(newUser, true);
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
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
                ModelState.AddModelError("", "E-poçt ünvanı və şifrə səhvdir");
                return View(loginViewModel);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "E-poçt ünvanı və şifrə səhvdir");
                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Dashboard");
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
    }
}