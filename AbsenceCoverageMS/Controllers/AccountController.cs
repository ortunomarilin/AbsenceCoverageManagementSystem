using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.ViewModels;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;

namespace AbsenceCoverageMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly UnitOfWork data;


        public AccountController(UserManager<User> userM, SignInManager<User> signInM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            signInManager = signInM;
            data = new UnitOfWork(ctx);
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


        
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            User user = await userManager.GetUserAsync(User);
            var model = new AccountViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PositionTitle = user.PositionTitle,
                Email = user.Email,
                Phone = user.PhoneNumber,
                CampusId = user.CampusId,
                Username = user.UserName,
                Campuses = data.Campuses.List(),
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            var model = new AccountViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PositionTitle = user.PositionTitle,
                Email = user.Email,
                Phone = user.PhoneNumber,
                CampusId = user.CampusId,
                Username = user.UserName,
                Campuses = data.Campuses.List(),
            };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.PositionTitle = model.PositionTitle;
                    user.PhoneNumber = model.Phone;
                    user.CampusId = model.CampusId;

                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["SucessMessage"] = "Profile, was updated successfully.";
                        return RedirectToAction("Details");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    TempData["FailureMessage"] = "Unable to submit profile changes. Please try again.";
                }
            }
            model.Campuses = data.Campuses.List();
            return View(model);
        }







    }
}