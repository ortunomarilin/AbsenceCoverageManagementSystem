using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Areas.PowerUser.Controllers
{
    [Authorize(Roles = "Power-User")]
    [Area("PowerUser")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}