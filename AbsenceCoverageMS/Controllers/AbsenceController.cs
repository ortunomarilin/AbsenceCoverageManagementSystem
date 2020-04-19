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
using Microsoft.EntityFrameworkCore;
using static AbsenceCoverageMS.Models.DomainModels.Enums;

namespace AbsenceCoverageMS.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly UnitOfWork data;
       
        //private readonly AbsenceManagementContext context; 
        //private readonly Repository<AbsenceRequest> arData;
        //private readonly Repository<AbsenceType> atData;
        //private readonly Repository<Period> periodData;


        public AbsenceController(UserManager<User> userM, AbsenceManagementContext ctx)
        {
            userManager = userM;
            data = new UnitOfWork(ctx);

            //arData = new Repository<AbsenceRequest>(ctx);
            //atData = new Repository<AbsenceType>(ctx);
            //periodData = new Repository<Period>(ctx);
        }


        [HttpGet]
        public IActionResult List()
        {
            var model = data.AbsenceRequests.List(new QueryOptions<AbsenceRequest>
            {
                OrderBy = ar => ar.StartDate,
                Include = "AbsenceType, User, PeriodsNeedCoverage"
            });

            return View(model);
        }
       


        [HttpGet]
        public IActionResult AbsenceRequest()
        {
            var model = new AbsenceRequestViewModel
            {
                AbsenceTypes = data.AbsenceTypes.List(new QueryOptions<AbsenceType> { OrderBy = at => at.Name}).ToList(),
                SelectablePeriods = new List<SelectablePeriodViewModel>(),
                StartTime = new DateTime(1,1,1,8,0,0),
                EndTime = new DateTime(1,1,1,16,0,0)
            };

            foreach(Period p in data.Periods.List())
            {
                SelectablePeriodViewModel period = new SelectablePeriodViewModel
                {
                    PeriodId = p.PeriodId,
                    Checked = false
                };
                model.SelectablePeriods.Add(period);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AbsenceRequest(AbsenceRequestViewModel model)
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
                        PeriodsNeedCoverage = new List<AbsenceRequestPeriod>(),
                        Status = Status.Submitted
                    };

                    foreach (SelectablePeriodViewModel p in model.SelectablePeriods)
                    {
                        if (p.Checked == true)
                        {
                            //Create a new Joint Entity AbsentRequestPeriod
                            AbsenceRequestPeriod absentRequestPeriod = new AbsenceRequestPeriod
                            {
                                AbsenceRequest = absentRequest,
                                PeriodId = p.PeriodId,
                            };
                            absentRequest.PeriodsNeedCoverage.Add(absentRequestPeriod);
                        }     
                    }

                    data.AbsenceRequests.Insert(absentRequest);
                    data.AbsenceRequests.Save();
                    return RedirectToAction("List");
                }
            }

            //If Fail re-populate Lists for Form selected options. 
            model.AbsenceTypes = data.AbsenceTypes.List(new QueryOptions<AbsenceType> { OrderBy = at => at.Name }).ToList();
            model.SelectablePeriods = new List<SelectablePeriodViewModel>();
            foreach (Period p in data.Periods.List())
            {
                SelectablePeriodViewModel period = new SelectablePeriodViewModel
                {
                    PeriodId = p.PeriodId,
                };
                model.SelectablePeriods.Add(period);
            }

            return View(model);
        }

    }
}