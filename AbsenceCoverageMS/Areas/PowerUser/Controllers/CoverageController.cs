using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
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



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult List()
        {
            var Jobs = data.SubJobs.List(new QueryOptions<SubJob>
            {
                Include = "AbsenceRequest, AbsenceRequest.DurationType, AbsenceRequest.User, AbsenceRequest.User.Campus, StatusType",
            });

            return View(Jobs);
        }


        public IActionResult Details(string id)
        {
            var subJob = data.SubJobs.Get(new QueryOptions<SubJob>
            {
                Include = "AbsenceRequest, AbsenceRequest.User, AbsenceRequest.User.Campus, DurationType, StatusType"
            });

            return View(subJob);
        }


    }
}