using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.SubTeacher.Models.ViewModels;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.QueryOptions;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Areas.SubTeacher.Controllers
{

    [Authorize(Roles = "Sub-Teacher")]
    [Area("SubTeacher")]
    public class SubJobController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly UnitOfWork data;


        public SubJobController(UserManager<User> userM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            data = new UnitOfWork(ctx);
        }


        public IActionResult Index()
        {
            return View();
        }


        public ViewResult List()
        {
            var Jobs = data.SubJobs.List(new QueryOptions<SubJob> 
            {
                Include = "AbsenceRequest, AbsenceRequest.DurationType, AbsenceRequest.User, AbsenceRequest.User.Campus, StatusType",
            });

            return View(Jobs);
        }


        [HttpGet]
        public ViewResult AvailableJobs(FilterGridDTO values)
        {
            //Create an instance of the SubJobeGridBuilder to save the route parameters for Sorting/Filtering the grid into a session. 
            var gridBuilder = new SubJobGridBuilder(HttpContext.Session, values, nameof(AbsenceRequest.StartDate));


            var options = new SubJobQueryOptions
            {
                Include = "AbsenceRequest, AbsenceRequest.DurationType, AbsenceRequest.User, AbsenceRequest.User.Campus, StatusType",
                Where = job => job.StatusType.Name == "Unfilled" && job.AbsenceRequest.StartDate >= DateTime.Now.Date,
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Filter(gridBuilder);
            options.Sort(gridBuilder);


            var model = new SubJobsAvailableViewModel
            {
                //Only available jobs (Unfilled). 
                AvailableSubJobs = data.SubJobs.List(options),
                Grid = gridBuilder.CurrentGrid,
                Campuses = data.Campuses.List(),
                DurationTypes = data.DurationTypes.List()
            };
            model.TotalPages = model.AvailableSubJobs.ToList().Count;

            //Finally Set the paging. 
            model.AvailableSubJobs = model.AvailableSubJobs.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View(model);

        }


        [HttpPost]
        public IActionResult Filter(string[] filters, bool clear = false)
        {
            //Initialize with the GET constructor (Desirializes route dictionary to use and make changes.)
            var gridBuilder = new SubJobGridBuilder(HttpContext.Session);

            if (clear)
            {
                gridBuilder.ClearSearchOptions();
            }
            else
            {
                //Set new filter value to current route and serialize. 
                gridBuilder.SetSearchOptions(filters);
                gridBuilder.SerializeRoutes();
            }

            //Redirect to the List Action Method with updated routes 
            return RedirectToAction("AvailableJobs", gridBuilder.CurrentGrid);
        }




    }
}