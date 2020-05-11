using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using AbsenceCoverageMS.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace AbsenceCoverageMS.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UnitOfWork data;


        public AbsenceController(UserManager<User> userM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            data = new UnitOfWork(ctx);
 
        }


        public async Task<ViewResult> List(AbsenceGridDTO parameters)
        {
            //First, find the current user signed in to only show their records. 
            User user = await userManager.GetUserAsync(User);

            //Create an instance of the AbsenceGridBuilder to save the route parameters for Sorting/Filtering the grid into a session. 
            var gridBuilder = new AbsenceGridBuilder(HttpContext.Session, parameters, nameof(AbsenceRequest.StartDate));


            //Set all of the Query options based on route parameters. Will apply these options to the ViewModel list of absence requests at the time of initialization. 
            var options = new AbsenceQueryOptions
            {
                Include = "AbsenceType, DurationType, StatusType, User, AbsenceRequestPeriods",
                Where = ar => ar.UserId == user.Id,
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
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

            //Finally Set the paging. 
            model.AbsenceRequests = model.AbsenceRequests.Skip((gridBuilder.CurrentGrid.PageNumber - 1) * gridBuilder.CurrentGrid.PageSize).Take(gridBuilder.CurrentGrid.PageSize);

            return View(model);
        }



        [HttpPost]
        public RedirectToActionResult Filter(string[] filters, string fromdate, string todate, bool clear = false)
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
                gridBuilder.SetSearchOptions(filters, fromdate, todate, null);
                gridBuilder.SerializeRoutes();
            }

            //Redirect to the List Action Method with updated routes 
            return RedirectToAction("List", gridBuilder.CurrentGrid);
        }



        [HttpGet]
        public async Task<IActionResult> Add()
        {
            User user = await userManager.GetUserAsync(User);
            if(user != null)
            {
                AbsenceViewModel model = new AbsenceViewModel
                {
                    AbsenceRequest = new AbsenceRequest
                    {
                        UserId = user.Id,
                        DateSubmitted = DateTime.Now,
                        StatusTypeId = data.StatusTypes.List().Where(s => s.Name == "Submitted").FirstOrDefault().StatusTypeId
                    },
                    AbsenceTypes = data.AbsenceTypes.List(),
                    DurationTypes = data.DurationTypes.List(),
                    SelectablePeriods = new List<SelectablePeriodViewModel>()
                };
                //Populate Period Check List
                model.SelectablePeriods = PopulateSelectablePeriodCheckList(model.SelectablePeriods);
               
                return View("Absence", model);
            }
            //If user is not logged on. Redirect to log in screen. 
            return RedirectToAction("LogIn", "Account");
        }


        [HttpPost]
        public IActionResult Add(AbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Check to make sure Need Coverage and Periods input match. 
                List<SelectablePeriodViewModel> checkedPeriods = model.SelectablePeriods.Where(p => p.Checked == true).ToList();

                if (model.NeedCoverageInput == "true" && checkedPeriods.Count == 0)
                {
                    ModelState.AddModelError("", "If coverage is needed, please check the periods that you will need coverage for.");
                }
                else if (model.NeedCoverageInput == "false" && checkedPeriods.Count != 0)
                {
                    ModelState.AddModelError("", "If no coverage is needed, checked periods are not allowed.");
                }
                else
                {
                    //Initialize the bool value for Need Coverage in Absence Request.
                    model.AbsenceRequest.NeedCoverage = model.NeedCoverageInput == "true" ? true : false;

                    //Add the records to the joint entity AbsenceRequestPeriod (Many-to-Many), by using the method in Unit of Work. 
                    data.AddNewAbsenceRequestPeriods(model.AbsenceRequest, model.SelectablePeriods);

                    //Inser the new record. 
                    data.AbsenceRequests.Insert(model.AbsenceRequest);

                    //Save the changes to the database. 
                    data.Save();

                    TempData["SucessMessage"] = "The Absence Request with ID# " + model.AbsenceRequest.AbsenceRequestId + ", was created successfully.";

                    return RedirectToAction("List");
                }
            }
            model.AbsenceTypes = data.AbsenceTypes.List();
            model.DurationTypes = data.DurationTypes.List();
            return View("Absence", model);
        }




        [HttpGet]
        public IActionResult Edit(string id)
        {
            AbsenceRequest absenceReqest = GetAbsenceRequest(id);
            AbsenceViewModel model = new AbsenceViewModel
            {
                AbsenceRequest = absenceReqest,
                NeedCoverageInput = absenceReqest.NeedCoverage == true ? "true" : "false",
                AbsenceTypes = data.AbsenceTypes.List(),
                DurationTypes = data.DurationTypes.List(),
                SelectablePeriods = new List<SelectablePeriodViewModel>()
            };

            //Populate Period Check List
            model.SelectablePeriods = PopulateSelectablePeriodCheckList(model.SelectablePeriods);

            //Show Check marks on Periods Need Coverage.
            foreach (AbsenceRequestPeriod p in absenceReqest.AbsenceRequestPeriods)
            {
                model.SelectablePeriods[p.Period.PeriodNumber -1].Checked = true;
            }
            return View("Absence", model);
        }



        [HttpPost]
        public IActionResult Edit(AbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Check to make sure Need Coverage and Periods input match. 
                List<SelectablePeriodViewModel> checkedPeriods = model.SelectablePeriods.Where(p => p.Checked == true).ToList();

                if (model.NeedCoverageInput == "true" && checkedPeriods.Count == 0)
                {
                    ModelState.AddModelError("", "If coverage is needed, please check the periods that you will need coverage for.");
                }
                else if (model.NeedCoverageInput == "false" && checkedPeriods.Count != 0)
                {
                    ModelState.AddModelError("", "If no coverage is needed, checked periods are not allowed.");
                }
                else
                {
                    //Initialize the bool value for Need Coverage in Absence Request.
                    model.AbsenceRequest.NeedCoverage = model.NeedCoverageInput == "true" ? true : false;

                    //Delete Old AbsenceRequestPeriod records from Joint Entity(Many-To-Many)
                    data.DeleteAbsenceRequestPeriods(model.AbsenceRequest);

                    //Create a new list of AbsenceRequestPeriods in the AbsenceRequest (Many-To-Many)
                    model.AbsenceRequest.AbsenceRequestPeriods = new List<AbsenceRequestPeriod>();

                    //Add the new periods checked to the joint entity AbsenceRequestPeriod (Many-to-Many), by using the method in Unit of Work. 
                    data.AddNewAbsenceRequestPeriods(model.AbsenceRequest, model.SelectablePeriods);

                    //Inser the new record. 
                    data.AbsenceRequests.Update(model.AbsenceRequest);

                    //Save the changes to the database. 
                    data.Save();

                    TempData["SucessMessage"] = "The Absence Request # " + model.AbsenceRequest.AbsenceRequestId + ", was successfully updated.";
                    return RedirectToAction("List");
                }
            }

            //If fail re-populate the lists
            model.AbsenceTypes = data.AbsenceTypes.List();
            model.DurationTypes = data.DurationTypes.List();
            return View("Absence", model);
        }




        [HttpGet]
        public ViewResult Details(string id)
        {
            AbsenceDetailsViewModel model = new AbsenceDetailsViewModel
            {
                AbsenceRequest = GetAbsenceRequest(id)
            };
            return View(model);
        }


        [HttpPost]
        public RedirectToActionResult Delete(string id)
        {
            AbsenceRequest absenceRequest = GetAbsenceRequest(id);
            if(absenceRequest.StatusType.Name != "Submitted")
            {
                TempData["FailureMessage"] = "Deletion Failed - Cannot delete absence request with a current status other than submitted. Please contact your manager.";
                return RedirectToAction("List");
            }
            data.AbsenceRequests.Delete(GetAbsenceRequest(id));
            data.AbsenceRequests.Save();
            return RedirectToAction("List");

        }





        private AbsenceRequest GetAbsenceRequest(string id)
        {
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
            {
                Where = ar => ar.AbsenceRequestId == id,
                Include = "AbsenceType, DurationType, StatusType, User, AbsenceRequestPeriods",
            });
            return absenceRequest;
        }

        private List<SelectablePeriodViewModel> PopulateSelectablePeriodCheckList(List<SelectablePeriodViewModel> selectablePeriodList)
        {
            //model.SelectablePeriods = new List<SelectablePeriodViewModel>();
            foreach (Period p in data.Periods.List())
            {
                SelectablePeriodViewModel selectablePeriod = new SelectablePeriodViewModel 
                { 
                    PeriodId = p.PeriodId 
                };
                //model.SelectablePeriods.Add(selectablePeriod);
                selectablePeriodList.Add(selectablePeriod);
            }
            //return model;
            return selectablePeriodList;
        }

    }
}