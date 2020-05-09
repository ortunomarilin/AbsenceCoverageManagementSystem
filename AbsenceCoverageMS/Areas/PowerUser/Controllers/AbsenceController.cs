using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels;
using AbsenceCoverageMS.Models;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Areas.PowerUser.Controllers
{

    [Authorize(Roles = "Power-User")]
    [Area("PowerUser")]

    public class AbsenceController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UnitOfWork data;


        public AbsenceController(UserManager<User> userM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            data = new UnitOfWork(ctx);
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListAsync(AbsenceGridDTO parameters)
        {
            //First get the current user logged in, to only show absence request from same campus. 
            User user = await userManager.GetUserAsync(User);

            //Create an instance of the AbsenceGridBuilder to save the route parameters for Sorting/Filtering the grid into a session. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session, parameters);


            //Set all of the Query options based on route parameters. Will apply these options to the ViewModel list of absence requests at the time of initialization. 
            var options = new AbsenceRequestQueryOptions
            {
                Include = "AbsenceType, DurationType, StatusType, User, AbsenceRequestPeriods",
                Where = ar => ar.User.CampusId == user.CampusId,
                OrderByDirection = gridBuilder.GetCurrentRoute.SortDirection,
            };
            options.FromDateRange(gridBuilder);
            options.Filter(gridBuilder);
            options.sort(gridBuilder);


            //Create and initialize the View Model 
            var model = new AbsenceListViewModel
            {
                //Set current route 
                Route = gridBuilder.GetCurrentRoute,

                //Absence Requests List with query options applied.
                AbsenceRequests = data.AbsenceRequests.List(options),

                //DropDown Lists 
                AbsenceTypes = data.AbsenceTypes.List(),
                DurationTypes = data.DurationTypes.List(),
                StatusTypes = data.StatusTypes.List(),
            };

            //model.AbsenceRequests = data.AbsenceRequests.List(new QueryOptions<AbsenceRequest>
            //{
            //    Include = "AbsenceType, DurationType, StatusType, User, AbsenceRequestPeriods",
            //    //Where = ar => ar.UserId == user.Id,
            //    OrderByDirection = gridBuilder.GetCurrentRoute.SortDirection,
            //});

            model.TotalPages = gridBuilder.GetTotalPages(model.AbsenceRequests.Count());

            //Finally Set the paging. 
            model.AbsenceRequests = model.AbsenceRequests.Skip((gridBuilder.GetCurrentRoute.PageNumber - 1) * gridBuilder.GetCurrentRoute.PageSize).Take(gridBuilder.GetCurrentRoute.PageSize);

            return View(model);
        }

    }
}