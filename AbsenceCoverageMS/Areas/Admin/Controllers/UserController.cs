using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.Admin.Models.ViewModels;
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
        public IActionResult Add()
        {
            UserAddViewModel model = new UserAddViewModel
            {
                Campuses = campusData.GetAll().ToList(),
                AvailableRoles = roleManager.Roles.ToList()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Set Properties for User Entity
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    TeachingSubjects = model.TeachingSubjects,
                    CampusId = model.CampusId,
                    Email = model.Email,
                    UserName = model.Username
                };

                //Create the User with the password. 
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Add to the selected role
                    IdentityRole role = await roleManager.FindByIdAsync(model.Id);
                    if(role != null)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                        return RedirectToAction("List");
                    }                   
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
            //Reset the dropdown list. 
            model.Campuses = campusData.GetAll().OrderBy(c => c.Name).ToList();
            model.AvailableRoles = roleManager.Roles.OrderBy(r => r.Name).ToList();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            var model = new UserEditViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.UserName,
                Position = user.Position,
                TeachingSubjects = user.TeachingSubjects,
                CampusId = user.CampusId,
                Campuses = campusData.GetAll(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.Position = model.Position;
                    user.TeachingSubjects = model.TeachingSubjects;
                    user.CampusId = model.CampusId;

                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        model.Campuses = campusData.GetAll();
                        return View(model);
                    }
                }
                ModelState.AddModelError("", "Unable to find User.");
            }
            model.Campuses = campusData.GetAll();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> ManageRoles(string id)
        {
            
            User user = await userManager.FindByIdAsync(id);
            UserManageRolesViewModel model = new UserManageRolesViewModel
            {
                UserId = user.Id,
                UserName = user.FullName,
                AvailableRoles = roleManager.Roles.ToList(),
            };

            foreach(var role in roleManager.Roles)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UsersRoles.Add(role);
                }
            }

            model.AvailableRoles =  model.AvailableRoles.OrderBy(r => r.Name).ToList();
            model.UsersRoles = model.UsersRoles.OrderBy(r => r.Name).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(UserManageRolesViewModel model, string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            User user = await userManager.FindByIdAsync(model.UserId);
            
            if(role != null && user != null)
            {
                var result = await userManager.AddToRoleAsync(user, role.Name);
                if(result.Succeeded)
                {
                    return RedirectToAction("ManageRoles", new { ID = model.UserId });
                }
            }

            TempData["ErrorMessage"] = "Unable to add the selected role.";
            return RedirectToAction("ManageRoles", new { ID = model.UserId });
        }


        [HttpPost]
        public async Task<IActionResult> RemoveRoleFromUser(UserManageRolesViewModel model, string id)
        {
            //Find User and role
            User user = await userManager.FindByIdAsync(model.UserId);
            IdentityRole role = await roleManager.FindByIdAsync(id);

            //If finding user and role was successful
            if (user != null && role != null)
            {
                var result = await userManager.RemoveFromRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return RedirectToAction("ManageRoles", new { ID = model.UserId });
                }
            }
            TempData["ErrorMessage"] = "Unable to delete the role from user.";
            return RedirectToAction("ManageRoles", new { ID = model.UserId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (!result.Succeeded) // if failed
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}