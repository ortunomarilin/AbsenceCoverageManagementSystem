using AbsenceCoverageMS.Areas.Admin.Models;
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
            var model = new AddRoleViewModel();
            
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddRoleViewModel model)
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

            EditRoleViewModel model = new EditRoleViewModel()
            {
                id = role.Id,
                RoleName = role.Name
            };


            foreach (User user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.roleUsers.Add(user);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.id);
            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
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
            return View(model);
        }



        //[HttpGet]
        //public IActionResult AssignRole()
        //{
        //    return View();
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