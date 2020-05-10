 using System;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.Admin.Models.ViewModels;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.QueryOptions;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbsenceCoverageMS.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UnitOfWork data;


        public UserController(UserManager<User> userM, RoleManager<IdentityRole> roleM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            roleManager = roleM;
            data = new UnitOfWork(ctx);
        }




        [HttpGet]
        public ViewResult List(UserGridDTO values)
        {
            var gridBuilder = new UserGridBuilder(HttpContext.Session, values, nameof(AbsenceCoverageMS.Models.DomainModels.User.FirstName));

            var options = new UserQueryOptions 
            {
                Include = "Campus",
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Search(gridBuilder);
            options.Filter(gridBuilder);
            options.Sort(gridBuilder);


            var model = new UserListViewModel
            {
                Grid = gridBuilder.CurrentGrid,
                Users = BuildQuery(options).ToList(),
                Campuses = data.Campuses.List()
            };
            model.TotalPages = gridBuilder.GetTotalPages(model.Users.Count());
            model.Users = model.Users.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View(model);
        }


        public RedirectToActionResult Search(string[] filters, string searchTerm, bool clear = false)
        {
            //Initialize with the GET constructor (Desirializes route dictionary to use and make changes.)
            var gridBuilder = new UserGridBuilder(HttpContext.Session);
            
            if (clear)
            {
                gridBuilder.ClearSearchOptions();
            }
            else
            {
                //Set new grid values and serialize. 
                gridBuilder.SetSearchOptions(filters, searchTerm);
                gridBuilder.SerializeRoutes();
            }

            //Redirect to the List Action Method with updated grid.
            return RedirectToAction("List", gridBuilder.CurrentGrid);

        }



        [HttpGet]
        public IActionResult Add()
        {
            UserAddViewModel model = new UserAddViewModel
            {
                //DropDowns 
                Campuses = data.Campuses.List(),
                Roles = roleManager.Roles
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Set Properties for User Entity
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PositionTitle = model.PositionTitle,
                    PhoneNumber = model.Phone,
                    CampusId = model.CampusId,
                    Email = model.Email,
                    UserName = model.Username
                };

                //Create the User with the password. 
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Check to see if a Role was selected 
                    if(model.RoleId != null)
                    {
                        //If a role was selected, find the selected role in the database. 
                        IdentityRole role = await roleManager.FindByIdAsync(model.RoleId);
                        if (role != null)
                        {
                            //If the role was found, add the user to the role selected. 
                            await userManager.AddToRoleAsync(user, role.Name);

                            //User and role where added, so redirect to User List page. 
                            TempData["SucessMessage"] = "User with name " + user.FullName + ", was created successfully.";
                            return RedirectToAction("List");
                        }
                        else
                        {
                            //If adding the user to the role selected failed add model errors to display on page. 
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                    else
                    {
                        //User was added, so redirect to User List page.
                        TempData["SucessMessage"] = "User with name " + user.FullName + ", was created successfully.";
                        return RedirectToAction("List");
                    }
                }
            }

            model.Campuses = data.Campuses.List();
            model.Roles = roleManager.Roles;
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
        public async Task<IActionResult> Edit(UserEditViewModel model)
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
                        TempData["SucessMessage"] = "The User with name " + user.FullName + ", was updated successfully.";
                        return RedirectToAction("List");
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
                    TempData["FailureMessage"] = "Unable to submit the user changes. Please try again.";
                } 
            }
            model.Campuses = data.Campuses.List();
            return View(model);
        }


        [HttpGet]
        public async Task<ViewResult> UserRoles(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            var model = new UserRolesViewModel
            {
                UserId = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                PositionTitle = user.PositionTitle,
                AvailableRoles = roleManager.Roles,
            };

            foreach (var role in roleManager.Roles)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRoles.Add(role);
                }
            }

            //Order the Lists by name. 
            model.AvailableRoles = model.AvailableRoles.OrderBy(r => r.Name).ToList();
            model.UserRoles = model.UserRoles.OrderBy(r => r.Name).ToList();

            return View(model);
        }



        [HttpPost]
        public async Task<RedirectToActionResult> AddRoleToUser(UserRolesViewModel model)
        {
            //First find both the current user, and role selected by ID. 
            User user = await userManager.FindByIdAsync(model.UserId);
            IdentityRole role = await roleManager.FindByIdAsync(model.RoleId);

            if(user != null && role != null )
            {
                var result = await userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    TempData["SucessMessage"] = "The role " + role.Name + ", was added to the user successfully.";
                    return RedirectToAction("UserRoles", new { ID = model.UserId });
                }
            }

            TempData["FailureMessage"] = "Unable to add the selected role. Please try again.";
            return RedirectToAction("UserRoles", new { ID = model.UserId });
        }


        [HttpPost]
        public async Task<RedirectToActionResult> DeleteRoleFromUser(UserRolesViewModel model)
        {
            //Find User and role
            User user = await userManager.FindByIdAsync(model.UserId);
            IdentityRole role = await roleManager.FindByIdAsync(model.RoleId);

            if (user != null && role != null)
            {
                var result = await userManager.RemoveFromRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    TempData["SucessMessage"] = "The role " + role.Name + ", was deleted from the user roles successfully.";
                    return RedirectToAction("UserRoles", new { ID = model.UserId });
                }
            }

            TempData["FailureMessage"] = "Unable to delete the selected role from the user roles. Please try again.";
            return RedirectToAction("UserRoles", new { ID = model.UserId });
        }


        [HttpGet]
        public async Task<ViewResult> Details(string id)
        {

            User user = await userManager.FindByIdAsync(id);
            var model = new UserEditViewModel
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
        public async Task<RedirectToActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded) 
                {
                    TempData["SucessMessage"] = "The User with name " + user.FullName + ", was deleted successfully.";
                    return RedirectToAction("List");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            TempData["FailureMessage"] = "Unable to delete the user. Please try again.";
            return RedirectToAction("List");
        }



        private IQueryable<User> BuildQuery(QueryOptions<User> options)
        {
            var query = userManager.Users;

            //Includes
            if (options.HasInclude)
            {
                foreach (string include in options.GetIncludes())
                {
                    query = query.Include(include);
                }
            }
            //Where
            if (options.HasWhere)
            {
                foreach (var where in options.WhereExpressions)
                {
                    query = query.Where(where);
                }
            }
            //OrderBy
            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "desc")
                    query = query.OrderByDescending(options.OrderBy);
                else
                    query = query.OrderBy(options.OrderBy);
            }

            return query;
        }
    }
}