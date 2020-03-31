using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.Admin.Models;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly Repository<Campus> campusData;


        public UserController(UserManager<User> userM, RoleManager<IdentityRole> roleM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            roleManager = roleM;
            campusData = new Repository<Campus>(ctx);
        }


        [HttpGet]
        public IActionResult List()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            //UserDetailsViewModel model = new UserDetailsViewModel();
            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            //model.Position = user.Position;
            //model.Campus.CampusId = user.Campus.CampusId;
            //model.Email = user.Email;
            //model.Username = user.UserName;

            //model.Roles = await userManager.GetRolesAsync(user);

            return View(new UserDetailsViewModel());
        }


        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddUserViewModel
            {
                Campuses = campusData.GetAll(),
                Roles = roleManager.Roles
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Properties for User Entity
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    CampusId = model.CampusId,
                    Email = model.Email,
                    UserName = model.Username
                };

                //Create the User with the model password. 
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(model.Id);

                    //Add user to role. 
                    await userManager.AddToRoleAsync(user, role.Name);

                    return RedirectToAction("List");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }

            model.Campuses = campusData.GetAll();
            model.Roles = roleManager.Roles;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {

            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded) // if failed
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                    return View("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}