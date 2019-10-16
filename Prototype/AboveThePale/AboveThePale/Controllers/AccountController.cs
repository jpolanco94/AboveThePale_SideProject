using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AboveThePale.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Web.Providers.Entities;


namespace AboveThePale.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signinManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
        {
            userManager = userMgr;
            signinManager = signinMgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signinManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signinManager.PasswordSignInAsync(
                            user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (details.Email == "admin@example.com")
                        {
                            return RedirectToAction("AdminHomePage", "Admin");
                        }
                        else
                        {
                            return Redirect(returnUrl ?? "/");
                        }
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
                    "Invalid user or password");
            }
            return View(details);
        }

        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("HomePage", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
