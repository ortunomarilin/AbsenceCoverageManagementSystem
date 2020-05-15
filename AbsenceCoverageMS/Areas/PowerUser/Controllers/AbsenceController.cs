﻿using System;
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
        public async Task<ViewResult> List(FilterGridDTO values)
        {
            //First get the current user logged in, to only show absence request from same campus. 
            User user = await userManager.GetUserAsync(User);

            //Create an instance of the AbsenceGridBuilder to save the grid values for Sorting/Paging/Filtering into a session. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session, values, nameof(AbsenceRequest.StartDate));


            //Set all of the Query options based on grid values. Will apply these options to the ViewModel list of absence requests at the time of initialization. 
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


            //Declare and initialize the View Model 
            var model = new AbsenceListViewModel
            {
                //Set current route 
                Grid = gridBuilder.CurrentGrid,

                //Absence Requests List with query options applied.
                AbsenceRequests = data.AbsenceRequests.List(options),

                //DropDown Lists 
                AbsenceTypes = data.AbsenceTypes.List(),
                DurationTypes = data.DurationTypes.List(),
                StatusTypes = data.StatusTypes.List(new QueryOptions<StatusType> { Where = st => st.Name != "Filled" && st.Name != "Unfilled"})
            };
            model.TotalPages = gridBuilder.GetTotalPages(model.AbsenceRequests.Count());
            model.AbsenceRequests = model.AbsenceRequests.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View(model);
        }

        

        [HttpPost]
        public RedirectToActionResult SearchOptions(string[] filters, string fromdate, string todate,  string searchTerm, bool clear = false)
        {
            //Initialize with the GET constructor (Desirializes Grid dictionary)
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);

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


        [HttpGet]
        public ViewResult Details(string id)
        {
            //Desirialize grid values to save values in View Model for model binding.
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);

            var model = new AbsenceDetailsViewModel
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
        public RedirectToActionResult Approve(AbsenceRequest model)
        {
            //First get the current Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(
                new QueryOptions<AbsenceRequest>
                {
                    Where = ar => ar.AbsenceRequestId == model.AbsenceRequestId,
                    Include = "StatusType, User, AbsenceRequestPeriods, AbsenceRequestPeriods.Period"
                });


            //Update absence with new changes. 
            absenceRequest.StatusType = data.StatusTypes.List().Where(st => st.Name == "Approved").FirstOrDefault();
            absenceRequest.DateProcessed = DateTime.Now;
            absenceRequest.StatusRemarks = model.StatusRemarks;
            data.AbsenceRequests.Update(absenceRequest);


            //If the Absence Request requires Coverage, create a sub job & coverage assignments with status of Unfilled. 
            if (absenceRequest.NeedCoverage)
            {
                var subJob = new SubJob
                {
                    AbsenceRequest = absenceRequest,
                    StatusType = data.StatusTypes.List().Where(st => st.Name == "Unfilled").FirstOrDefault()
                };
                data.AddNewCoverageAssignments(subJob);
                data.SubJobs.Insert(subJob);
            }

            //Save all changes
            data.Save();

            //To retain grid state, send the current grid values to the List View. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);
            return RedirectToAction("List", gridBuilder.CurrentGrid);
        }



        [HttpPost]
        public IActionResult Deny(AbsenceRequest model)
        {
            //To retain grid state, send the current grid values to the List View. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);

            //First get the current Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(
                new QueryOptions<AbsenceRequest>
                {
                    Where = ar => ar.AbsenceRequestId == model.AbsenceRequestId,
                    Include = "StatusType, User, AbsenceRequestPeriods, AbsenceRequestPeriods.Period"
                });

            if (model.StatusRemarks == null)
            {
                TempData["FailureMessage"] = "Unable to Deny the Absence Request for " + absenceRequest.User.FullName + ". If absence is denied, need to provide a reason in status remarks.";
                //return RedirectToAction("List", gridBuilder.CurrentGrid);
                return RedirectToAction("List", gridBuilder.CurrentGrid);
            }
            else
            {

                //Update absence with new changes. 
                absenceRequest.StatusType = data.StatusTypes.List().Where(st => st.Name == "Denied").FirstOrDefault();
                absenceRequest.DateProcessed = DateTime.Now;
                absenceRequest.StatusRemarks = model.StatusRemarks;
                data.AbsenceRequests.Update(absenceRequest);

                //Save all changes
                data.Save();
                return RedirectToAction("List", gridBuilder.CurrentGrid);

            }


        }




        [HttpPost]
        public RedirectToActionResult Cancel(AbsenceRequest model)
        {
            //First get the current Absence Request 
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(
                new QueryOptions<AbsenceRequest>
                {
                    Where = ar => ar.AbsenceRequestId == model.AbsenceRequestId,
                    Include = "StatusType, User, AbsenceRequestPeriods, AbsenceRequestPeriods.Period, SubJob, SubJob.StatusType, SubJob.CoverageAssignments"
                });


            if(absenceRequest.SubJob != null)
            {
                //If the absence request has a sub job that has been filled change the staus to "Canceled"
                if (absenceRequest.SubJob.StatusType.Name == "Filled")
                {
                    absenceRequest.StatusType = data.StatusTypes.List().Where(st => st.Name == "Canceled").FirstOrDefault();
                    absenceRequest.SubJob.StatusType = data.StatusTypes.List().Where(st => st.Name == "Canceled").FirstOrDefault();

                    foreach (CoverageAssignment coverageAssignment in absenceRequest.SubJob.CoverageAssignments)
                    {
                        coverageAssignment.StatusType = data.StatusTypes.List().Where(st => st.Name == "Canceled").FirstOrDefault();
                    }
                }
                //Else delete, since the absence has not been filled by a sub. 
                else
                {
                    data.AbsenceRequests.Delete(absenceRequest);
                    data.SubJobs.Delete(absenceRequest.SubJob);
                    data.DeleteCoverageAssignments(absenceRequest.SubJob);
                }
            }
            //Else no coverage was requested, so can go ahead and delete.  
            else
            {
                data.AbsenceRequests.Delete(absenceRequest);
            }

            //Save all changes
            data.Save();

            //To retain grid state, send the current grid values to the List View. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session);
            return RedirectToAction("List", gridBuilder.CurrentGrid);
        }

    }
}