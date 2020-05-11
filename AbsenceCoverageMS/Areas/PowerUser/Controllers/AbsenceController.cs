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


        [HttpGet]
        public async Task<ViewResult> ListAsync(AbsenceGridDTO parameters)
        {
            //First get the current user logged in, to only show absence request from same campus. 
            User user = await userManager.GetUserAsync(User);

            //Create an instance of the AbsenceGridBuilder to save the route parameters for Sorting/Filtering the grid into a session. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session, parameters, nameof(AbsenceRequest.StartDate));


            //Set all of the Query options based on route parameters. Will apply these options to the ViewModel list of absence requests at the time of initialization. 
            var options = new AbsenceQueryOptions
            {
                Include = "AbsenceType, DurationType, StatusType, User, AbsenceRequestPeriods",
                Where = ar => ar.User.CampusId == user.CampusId,
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Search(gridBuilder);
            options.FromDateRange(gridBuilder);
            options.Filter(gridBuilder);
            options.Sort(gridBuilder);


            //Create and initialize the View Model 
            var model = new AbsenceListViewModel
            {
                //Set current route 
                Grid = gridBuilder.CurrentGrid,

                //Absence Requests List with query options applied.
                AbsenceRequests = data.AbsenceRequests.List(options),

                //DropDown Lists 
                AbsenceTypes = data.AbsenceTypes.List(),
                DurationTypes = data.DurationTypes.List(),
                StatusTypes = data.StatusTypes.List(),
            };
            model.TotalPages = gridBuilder.GetTotalPages(model.AbsenceRequests.Count());
            model.AbsenceRequests = model.AbsenceRequests.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View(model);
        }

        
        [HttpPost]
        public RedirectToActionResult SearchOptions(string[] filters, string fromdate, string todate,  string searchTerm, bool clear = false)
        {
            //Initialize with the GET constructor (Desirializes route dictionary to use and make changes.)
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);

            if (clear)
            {
                gridBuilder.ClearSearchOptions();
            }
            else
            {
                //Set new filter value to current route and serialize. 
                gridBuilder.SetSearchOptions(filters, fromdate, todate, searchTerm);
                gridBuilder.SerializeRoutes();
            }

            //Redirect to the List Action Method with updated routes 
            return RedirectToAction("List", gridBuilder.CurrentGrid);
        }

    }
}