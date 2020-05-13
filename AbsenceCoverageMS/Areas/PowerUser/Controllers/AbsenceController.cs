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
using Microsoft.AspNetCore.Server.IIS.Core;

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





        [HttpGet]
        public async Task<ViewResult> List(AbsenceGridDTO parameters)
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





        [HttpGet]
        public ViewResult ProcessAbsence(string id)
        {
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);

            var model = new AbsenceProcessAbsenceViewModel
            {
                Grid = gridBuilder.CurrentGrid,
                AbsenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
                {
                    Where = ar => ar.AbsenceRequestId == id,
                    Include = "AbsenceType, DurationType, StatusType, User, AbsenceRequestPeriods"
                })
            };
            return View(model);
        }



        [HttpPost]
        public RedirectToActionResult ProcessAbsence(AbsenceProcessAbsenceViewModel model, bool approve = false, bool deny = false)
        {
            //Get the current Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(
                new QueryOptions<AbsenceRequest>
                {
                    Where = ar => ar.AbsenceRequestId == model.AbsenceRequest.AbsenceRequestId,
                    Include = "StatusType, User"
                });


            if (approve)
            {
                //Change the status type to "Approved". 
                absenceRequest.StatusType = data.StatusTypes.Get(
                    new QueryOptions<StatusType>
                    {
                        Where = st => st.Name == "Approved"
                    });
            }

            else if(deny)
            {
                //Change the status type to "Deny". 
                absenceRequest.StatusType = data.StatusTypes.Get(
                    new QueryOptions<StatusType>
                    {
                        Where = st => st.Name == "Denied"
                    });
            }

            absenceRequest.DateProcessed = DateTime.Now;
            absenceRequest.StatusRemarks = model.AbsenceRequest.StatusRemarks;

            //Update and save. 
            data.AbsenceRequests.Update(absenceRequest);
            data.Save();


            TempData["SucessMessage"] = "The Absence Request for " + absenceRequest.User.FullName + " was processed sucessfully.";
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);
            return RedirectToAction("List", gridBuilder.CurrentGrid);
        }








    }
}