using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Controllers
{
    [Authorize]
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
            //First, find the current user signed in to only show their records. 
            User user = await userManager.GetUserAsync(User);
            var absenceRequests = data.AbsenceRequests.List(new QueryOptions<AbsenceRequest> 
            {
                Include = "AbsenceStatus, AbsenceType",
                Where = ar => ar.UserId == user.Id
            });


            HomeViewModel model = new HomeViewModel
            {
                WaitingApproval = absenceRequests.Where(ar => ar.AbsenceStatus.Name == "Submitted").Count(),
                Approved = absenceRequests.Where(ar => ar.AbsenceStatus.Name == "Approved").Count(),
                Denied = absenceRequests.Where(ar => ar.AbsenceStatus.Name == "Denied").Count(),
                TotalAbsences = new Dictionary<string, int> ()
            };

            //Fill in the dictionary for Total Absences taken. 
            foreach(AbsenceType absenceType in data.AbsenceTypes.List())
            {
                //Only include approved
                model.TotalAbsences.Add(absenceType.Name, absenceRequests.Where(ar => ar.AbsenceType.Name == absenceType.Name && ar.AbsenceStatus.Name == "Approved").Count());
            }

            return View(model);
        }
        


        
    }
}