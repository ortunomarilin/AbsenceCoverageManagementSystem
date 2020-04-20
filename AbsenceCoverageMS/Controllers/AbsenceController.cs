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
        public async Task<IActionResult> AddAsync()
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            Campus campus = data.Campuses.Get(new QueryOptions<Campus> { Where = c => c.CampusId == user.CampusId });

            var model = new AbsenceAddViewModel
            {
                AbsenceTypes = data.AbsenceTypes.List(new QueryOptions<AbsenceType> { OrderBy = at => at.Name}).ToList(),
                SelectablePeriods = new List<SelectablePeriodViewModel>(),
                StartTime = campus.OpenTime, 
                EndTime = campus.CloseTime 
            };

            foreach(Period p in data.Periods.List())
            {
                SelectablePeriodViewModel period = new SelectablePeriodViewModel { PeriodId = p.PeriodId };
                model.SelectablePeriods.Add(period);
            }
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> Add(AbsenceAddViewModel model)
        {
            if(model != null)
            {
                if(ModelState.IsValid)
                {
                    User user = await userManager.FindByNameAsync(User.Identity.Name);
                    AbsenceRequest absentRequest = new AbsenceRequest
                    {
                        UserId = user.Id,
                        DateSubmitted = DateTime.Now,
                        AbsenceTypeId = model.AbsenceTypeId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                        Duration = model.Duration,
                        NeedCoverage = model.NeedCoverage == NeedCoverage.Yes ? true : false,
                        AbsenceRequestPeriods = new List<AbsenceRequestPeriod>(),
                        Status = Status.Submitted
                    };

                    foreach (SelectablePeriodViewModel p in model.SelectablePeriods)
                    {
                        if (p.Checked == true)
                        {
                            //Add to Joint Entity AbsentRequestPeriod
                            AbsenceRequestPeriod absentRequestPeriod = new AbsenceRequestPeriod
                            {
                                AbsenceRequest = absentRequest,
                                PeriodId = p.PeriodId,
                            };
                            absentRequest.AbsenceRequestPeriods.Add(absentRequestPeriod);
                        }     
                    }

                    data.AbsenceRequests.Insert(absentRequest);
                    data.AbsenceRequests.Save();
                    return RedirectToAction("List");
                }
            }

            //If failed re-populate Lists for Form select options. 
            model.AbsenceTypes = data.AbsenceTypes.List(new QueryOptions<AbsenceType> { OrderBy = at => at.Name }).ToList();
            model.SelectablePeriods = new List<SelectablePeriodViewModel>();
            foreach (Period p in data.Periods.List())
            {
                SelectablePeriodViewModel period = new SelectablePeriodViewModel{ PeriodId = p.PeriodId };
                model.SelectablePeriods.Add(period);
            }

            return View(model);
        }

    }
}