using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Areas.PowerUser.Controllers
{
    [Authorize(Roles = "Power-User")]
    [Area("PowerUser")]
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UnitOfWork data;


        public HomeController(UserManager<User> userM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            data = new UnitOfWork(ctx);
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Find user to only account for employee absences under their management. 
            User user = await userManager.GetUserAsync(User);

            
            return View();
        }




    }
}