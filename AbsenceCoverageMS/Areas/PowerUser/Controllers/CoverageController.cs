using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels;
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
                Include = "DurationType, AbsenceRequestPeriods, AbsenceStatusType, User, SubJob, SubJob.SubJobStatus",
                Where = ar => ar.User.CampusId == user.CampusId  && ar.AbsenceStatus.Name == "Approved" && ar.NeedCoverage == true,
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
                SubJobStatuses = data.SubJobStatuses.List()
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
                    Include = "DurationType, AbsenceRequestPeriods, User, SubJob, SubJob.User, SubJob.SubJobStatus",
                    Where = ar => ar.AbsenceRequestId == id,
                }),

                Dates = new List<string>()
            };

            for (DateTime date = model.AbsenceRequest.StartDate.Value; date <= model.AbsenceRequest.EndDate.Value; date = date.AddDays(1))
            {
                model.Dates.Add(date.ToShortDateString());
            }

            return View(model);
        }




        [HttpPost]
        public IActionResult AddSubJob(string id, bool list = false)
        {
            //First get the Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
            {
                Include = "DurationType, AbsenceRequestPeriods, User, SubJob, SubJob.User, SubJob.SubJobStatus",
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
                SubJobStatus = data.SubJobStatuses.List().Where(ct => ct.Name == "Unfilled").FirstOrDefault(),
                AbsenceRequest = absenceRequest 
            };
            data.SubJobs.Insert(subJob);
            data.Save();


            if(list)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Details", new { ID = absenceRequest.AbsenceRequestId });
            }

            
        }



        public IActionResult DeleteSubJob(string id, bool list = false)
        {
            //First get the Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
            {
                Include = "DurationType, AbsenceRequestPeriods, User, SubJob, SubJob.User, SubJob.SubJobStatus",
                Where = ar => ar.AbsenceRequestId == id,
            });


            data.SubJobs.Delete(absenceRequest.SubJob);
            data.Save();


            if (list)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Details", new { ID = absenceRequest.AbsenceRequestId });
            }




        }

    }
}