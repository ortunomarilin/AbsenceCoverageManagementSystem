using AbsenceCoverageMS.Areas.Admin.Models;
using AbsenceCoverageMS.Areas.Admin.Models.ViewModels;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
       private readonly UserManager<User> userManager; 
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(UserManager<User> userM, RoleManager<IdentityRole> roleM)
        {
            userManager = userM;
            roleManager = roleM;
        }

        [HttpGet]
        public IActionResult List()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new RoleAddViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(RoleAddViewModel model)
        {
            if (model != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(model.RoleName));
                    if (result.Succeeded)
                    {
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
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            RoleEditViewModel model = new RoleEditViewModel { RoleId = id, RoleName = role.Name };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleId);
            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                else
                {
                    return RedirectToAction("List");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageUsers(string id)
        {
         
            IdentityRole role = await roleManager.FindByIdAsync(id);

            RoleManageUsersViewModel model = new RoleManageUsersViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            foreach (User user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.RoleUsers.Add(user);
                }
                
                RoleAddUsers AvailableUser = new RoleAddUsers { UserId = user.Id, Name = user.FullName, Checked = false };
                model.AvailableUsers.Add(AvailableUser);
            }

            return View(model);
        }

        //[HttpGet]
        //public IActionResult AddUsersToRole()
        //{

        //    return View("ManageUsers");

        //}









        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("List");

            }
            return View();

        }
    }


}