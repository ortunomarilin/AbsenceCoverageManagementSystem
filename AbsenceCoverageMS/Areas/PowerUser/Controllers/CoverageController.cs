using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels;
using AbsenceCoverageMS.Models;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.QueryOptions;
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
    public class CoverageController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly UnitOfWork data;


        public CoverageController(UserManager<User> userM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            data = new UnitOfWork(ctx);
        }





        public async Task<IActionResult> List(FilterGridDTO values)
        {
            User user = await userManager.GetUserAsync(User);

            var gridBuilder = new CoverageGridBuilder(HttpContext.Session, values, nameof(AbsenceRequest.StartDate));

            var options = new CoverageQueryOptions
            {
                Include = "DurationType, AbsenceRequestPeriods, User, SubJob, SubJob.CoverageStatusType",
                Where = ar => ar.User.CampusId == user.CampusId  && ar.AbsenceStatusType.Name == "Approved" && ar.NeedCoverage == true ,
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Search(gridBuilder);
            options.FromDateRange(gridBuilder);
            options.Filter(gridBuilder);
            options.Sort(gridBuilder);


            CoverageListViewModel model = new CoverageListViewModel
            {
                Grid = gridBuilder.CurrentGrid,
                AbsenceRequests = data.AbsenceRequests.List(options),
                DurationTypes = data.DurationTypes.List(),
                CoverageStatusTypes = data.CoverageStatusTypes.List()
            };

            model.TotalPages = gridBuilder.GetTotalPages(model.AbsenceRequests.Count());
            model.AbsenceRequests = model.AbsenceRequests.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View(model);
        }


        [HttpPost]
        public RedirectToActionResult SearchOptions(string[] filters, string fromdate, string todate, string searchTerm, bool clear = false)
        {
            //Initialize with the GET constructor (Desirializes Grid dictionary)
            var gridBuilder = new CoverageGridBuilder(HttpContext.Session);

            if (clear)
            {
                gridBuilder.ClearSearchOptions();
            }
            else
            {
                //Set new filter value to current grid and serialize. 
                gridBuilder.SetSearchOptions(filters, fromdate, todate, searchTerm);
                gridBuilder.SerializeRoutes();
            }

            //Redirect to the List Action Method with updated grid dictionary 
            return RedirectToAction("List", gridBuilder.CurrentGrid);
        }


        public IActionResult Details(string id)
        {

            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);

            CoverageDetailsViewModel model = new CoverageDetailsViewModel 
            {
                Grid = gridBuilder.CurrentGrid,

                AbsenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest> 
                    {
                    Include = "DurationType, AbsenceRequestPeriods, User, SubJob, CoverageJobs, SubJob.User, SubJob.CoverageStatusType, CoverageJobs.CoverageStatusType",
                    Where = ar => ar.AbsenceRequestId == id,
                    }),
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult AddSubJob(string id)
        {
            //First get the Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
            {
                Include = "DurationType, AbsenceRequestPeriods, User, SubJob, CoverageJobs, SubJob.User, SubJob.CoverageStatusType, CoverageJobs.CoverageStatusType",
                Where = ar => ar.AbsenceRequestId == id,
            });

            //Then copy the absence values to the new sub job.
            SubJob subJob = new SubJob 
            {
                StartDate = absenceRequest.StartDate,
                EndDate = absenceRequest.EndDate,
                StartTime = absenceRequest.StartTime,
                EndTime = absenceRequest.EndTime,
                DurationTypeId = absenceRequest.DurationTypeId,
            };


            var model = new CoverageAddSubJobViewModel
            {
                AbsenceRequestId = absenceRequest.AbsenceRequestId,
                SubJob = subJob,
                DurationTypes = data.DurationTypes.List()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult AddSubJob(CoverageAddSubJobViewModel model)
        {
            if(ModelState.IsValid)
            {
                model.SubJob.AbsenceRequestId = model.AbsenceRequestId;
                model.SubJob.CoverageStatusType = data.CoverageStatusTypes.List().Where(ct => ct.Name == "Unfilled").FirstOrDefault();
                data.SubJobs.Insert(model.SubJob);
                data.Save();

                return RedirectToAction("Details", new { ID = model.AbsenceRequestId });
            }

            model.DurationTypes = data.DurationTypes.List();
            return View(model);
        }



        public IActionResult DeleteSubJob(string id)
        {
            //First get the Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
            {
                Include = "DurationType, AbsenceRequestPeriods, User, SubJob, CoverageJobs, SubJob.User, SubJob.CoverageStatusType, CoverageJobs.CoverageStatusType",
                Where = ar => ar.AbsenceRequestId == id,
            });

            if(absenceRequest.SubJob.CoverageStatusType.Name == "Filled")
            {
                // 1) Create a notification to the Sub-Teacher that the record will be deleted. 
                // 2) Redirect to the Details View. 

            }

            data.SubJobs.Delete(absenceRequest.SubJob);
            data.Save();
            return RedirectToAction("Details", new { ID = absenceRequest.AbsenceRequestId });

        }

    }
}