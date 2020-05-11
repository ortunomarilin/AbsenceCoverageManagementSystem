using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.ViewModels;

namespace AbsenceCoverageMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;


        public AccountController(UserManager<User> userM, SignInManager<User> signInM)
        {
            userManager = userM;
            signInManager = signInM;
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            LogInViewModel model = new LogInViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await signInManager.UserManager.FindByNameAsync(model.Username);

                    //Check to see which role the user is in to redirect to correct Home Page.  
                    bool isAdmin = await signInManager.UserManager.IsInRoleAsync(user, "admin");
                    bool isPowerUser = await signInManager.UserManager.IsInRoleAsync(user, "power-user");


                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    if(isPowerUser)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "PowerUser" });
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }







    }
}