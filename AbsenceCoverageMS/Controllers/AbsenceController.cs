using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static AbsenceCoverageMS.Models.DomainModels.Enums;

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



        [HttpGet]
        public async Task<IActionResult> List()
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = data.AbsenceRequests.List(new QueryOptions<AbsenceRequest>
            {
                Where = ar => ar.UserId == user.Id,
                OrderBy = ar => ar.StartDate,
                Include = "AbsenceType, User, AbsenceRequestPeriods"
            });
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(string id)
        {
            AbsenceDetailsViewModel model = new AbsenceDetailsViewModel
            {
                AbsenceRequest = GetAbsenceRequest(id)
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            AbsenceViewModel model = new AbsenceViewModel
            {
                AbsenceRequest = new AbsenceRequest { UserId = user.Id, DateSubmitted = DateTime.Now, Status = Enums.Status.Submitted },
            };

            //Populate Select Lists (Dropdown / Checklist)
            model = PopulateSelectLists(model);

            return View("Absence", model);
        }


        [HttpPost]
        public IActionResult Add(AbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Check to make sure Need Coverage and Periods need covered input match. 
                List<SelectablePeriodViewModel> checkedPeriods = model.SelectablePeriods.Where(p => p.Checked == true).ToList();

                if(model.NeedCoverage == Enums.NeedCoverage.Yes && checkedPeriods.Count == 0)
                {
                    //Checked periods are required if need coverage is selected. 
                    ModelState.AddModelError("", "If coverage is needed, please check the periods that will need coverage.");
                    model = PopulateSelectLists(model);
                    return View("Absence", model);
                }
                else if (model.NeedCoverage == Enums.NeedCoverage.No && checkedPeriods.Count != 0)
                {
                    //Checked periods are not allowed if no coverage is needed.
                    ModelState.AddModelError("", "If no coverage is needed, checked periods are not allowed.");
                    model = PopulateSelectLists(model);
                    return View("Absence", model);
                }
                else
                {
                    model.AbsenceRequest.NeedCoverage = model.NeedCoverage == NeedCoverage.Yes ? true : false;

                    //Initialize the list of AbsenceRequestPeriod (Many-To-Many)
                    model.AbsenceRequest.AbsenceRequestPeriods = new List<AbsenceRequestPeriod>();

                    //Add AbsenceRequestPeriod (Periods Need Coverage)
                    data.AddNewAbsenceRequestPeriods(model.AbsenceRequest, model.SelectablePeriods);

                    //Insert and save into database. 
                    data.AbsenceRequests.Insert(model.AbsenceRequest);
                    data.AbsenceRequests.Save();

                    return RedirectToAction("List");
                }
            }
            //If fail re-populate the lists
            model = PopulateSelectLists(model);
            return View("Absence", model);
        }



        [HttpGet]
        public IActionResult Edit(string id)
        {
            AbsenceRequest absenceReqest = GetAbsenceRequest(id);
            AbsenceViewModel model = new AbsenceViewModel
            {
                AbsenceRequest = absenceReqest,
                NeedCoverage = absenceReqest.NeedCoverage == true ? Enums.NeedCoverage.Yes : Enums.NeedCoverage.No,
            };

            //Populate Select Lists (Dropdown / Checklist)
            model = PopulateSelectLists(model);

            //Show Check marks on AbsenceRequestPeriod records. (Periods Need Coverage)
            for (int i = 0; i < absenceReqest.AbsenceRequestPeriods.ToList().Count(); i++)
            {
                model.SelectablePeriods[i].Checked = true;
            }

            return View("Absence", model);
        }


        [HttpPost]
        public IActionResult Edit(AbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Check to make sure Need Coverage and Periods need covered input match. 
                List<SelectablePeriodViewModel> checkedPeriods = model.SelectablePeriods.Where(p => p.Checked == true).ToList();

                if (model.NeedCoverage == Enums.NeedCoverage.Yes && checkedPeriods.Count == 0)
                {
                    //Checked periods are required if need coverage is selected. 
                    ModelState.AddModelError("", "If coverage is needed, please check the periods that will need coverage.");
                    model = PopulateSelectLists(model);
                    return View("Absence", model);
                }
                else if (model.NeedCoverage == Enums.NeedCoverage.No && checkedPeriods.Count != 0)
                {
                    //Checked periods are not allowed if no coverage is needed. 
                    ModelState.AddModelError("", "If no coverage is needed, checked periods are not allowed.");
                    model = PopulateSelectLists(model);
                    return View("Absence", model);
                }
                else
                {
                    model.AbsenceRequest.NeedCoverage = model.NeedCoverage == NeedCoverage.Yes ? true : false;

                    //Initialize the list of AbsenceRequestPeriod (Many-To-Many)
                    model.AbsenceRequest.AbsenceRequestPeriods = new List<AbsenceRequestPeriod>();

                    //Delete Old AbsenceRequestPeriod (Many-To-Many)
                    data.DeleteAbsenceRequestPeriods(model.AbsenceRequest);

                    //Add AbsenceRequestPeriod (Many-To-Many)
                    data.AddNewAbsenceRequestPeriods(model.AbsenceRequest, model.SelectablePeriods);

                    //Insert and save into database. 
                    data.AbsenceRequests.Update(model.AbsenceRequest);
                    data.AbsenceRequests.Save();

                    return RedirectToAction("List");
                }
            }

            //If fail re-populate the lists
            model = PopulateSelectLists(model);
            return View("Absence", model);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            data.AbsenceRequests.Delete(GetAbsenceRequest(id));
            data.AbsenceRequests.Save();
            return RedirectToAction("List");
        }


        private AbsenceRequest GetAbsenceRequest(string id)
        {
            AbsenceRequest absenceRequest = data.AbsenceRequests.Get(new QueryOptions<AbsenceRequest>
            {
                Where = ar => ar.AbsenceRequestId == id,
                Include = "AbsenceType, User, AbsenceRequestPeriods"
            });
            return absenceRequest;
        }

        private AbsenceViewModel PopulateSelectLists(AbsenceViewModel model)
        {
            model.AbsenceTypes = data.AbsenceTypes.List().ToList();

            model.SelectablePeriods = new List<SelectablePeriodViewModel>();
            foreach (Period p in data.Periods.List())
            {
                SelectablePeriodViewModel period = new SelectablePeriodViewModel { PeriodId = p.PeriodId };
                model.SelectablePeriods.Add(period);
            }

            return model;
        }

    }
}