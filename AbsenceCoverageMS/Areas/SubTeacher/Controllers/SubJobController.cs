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

    //[Authorize(Roles = "Sub-Teacher")]
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



        [HttpGet]
        public async Task<IActionResult> JobHistory(FilterGridDTO values)
        {
            //First, find the current user signed in, only show accepted jobs. 
            User user = await userManager.GetUserAsync(User);

            //Create an instance of the SubJobeGridBuilder to save the route parameters for Sorting/Filtering the grid into a session. 
            var gridBuilder = new SubJobGridBuilder(HttpContext.Session, values, nameof(SubJob.StartDate));

            var options = new SubJobQueryOptions
            {
                Include = "AbsenceRequest, AbsenceRequest.DurationType, AbsenceRequest.User, AbsenceRequest.User.Campus, SubJobStatus",
                Where = job => job.User.Id == user.Id,
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Filter(gridBuilder);
            options.Sort(gridBuilder);


            var model = new SubJobsHistoryViewModel
            {
                SubJobs = data.SubJobs.List(options),
                Grid = gridBuilder.CurrentGrid,
                Campuses = data.Campuses.List(),
                DurationTypes = data.DurationTypes.List()
            };
            model.TotalPages = model.SubJobs.ToList().Count;

            //Finally Set the paging. 
            model.SubJobs = model.SubJobs.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View("JobHistory", model);

        }

        [HttpPost]
        public IActionResult JobHistoryFilter(string[] filters, bool clear = false)
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
            return RedirectToAction("JobHistory", gridBuilder.CurrentGrid);
        }




        [HttpGet]
        public IActionResult AvailableJobs(FilterGridDTO values)
        {
            //Create an instance of the SubJobeGridBuilder to save the route parameters for Sorting/Filtering the grid into a session. 
            var gridBuilder = new SubJobGridBuilder(HttpContext.Session, values, nameof(SubJob.StartDate));

            var options = new SubJobQueryOptions
            {
                Include = "AbsenceRequest, AbsenceRequest.DurationType, AbsenceRequest.User, AbsenceRequest.User.Campus, SubJobStatus",
                Where = job => job.SubJobStatus.Name == "Unfilled" && job.StartDate >= DateTime.Now.Date,
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Filter(gridBuilder);
            options.Sort(gridBuilder);

            var model = new SubJobsAvailableViewModel
            {
                AvailableSubJobs = data.SubJobs.List(options),
                Grid = gridBuilder.CurrentGrid,
                Campuses = data.Campuses.List(),
                DurationTypes = data.DurationTypes.List()
            };
            model.TotalPages = model.AvailableSubJobs.ToList().Count;

            //Finally Set the paging. 
            model.AvailableSubJobs = model.AvailableSubJobs.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View("AvailableJobs", model);

        }


        [HttpPost]
        public IActionResult AvailableJobsFilter(string[] filters, bool clear = false)
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


        [HttpPost]
        public async Task<IActionResult> AcceptJob(string id)
        {
            //First, find the current user signed in, this will be the Sub accepting the sub job. 
            User user = await userManager.GetUserAsync(User);

            //Second, find the SubJob being accepted.
            SubJob subJob = data.SubJobs.Get(new QueryOptions<SubJob>
            {
                Where = job => job.SubJobId == id,
                Include = "SubJobStatus, User, AbsenceRequest, DurationType",
            });

            //Finally assing Sub to Sub Job / change status to filled. 
            subJob.User = user;
            subJob.SubJobStatus.Name = "Filled";

            data.SubJobs.Update(subJob);
            data.Save();


            //Redirect to the List Action Method with updated routes 
            return RedirectToAction("AvailableJobs");
        }


        public IActionResult CancelAcceptance(string id)
        {
            SubJob subJob = data.SubJobs.Get(new QueryOptions<SubJob>
            {
                Where = job => job.SubJobId == id,
                Include = "SubJobStatus, User, AbsenceRequest, DurationType",
            });

            //Finally assing Sub to Sub Job / change status to filled. 
            subJob.User = null;
            subJob.SubJobStatus.Name = "Unfilled";

            data.SubJobs.Update(subJob);
            data.Save();


            //Redirect to the job history 
            return RedirectToAction("JobHistory");

        }




    }
}