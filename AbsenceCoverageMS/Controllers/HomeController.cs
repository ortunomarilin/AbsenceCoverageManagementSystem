using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<User> signInManager;


        public HomeController(SignInManager<User> signInM)
        {
            signInManager = signInM;
        }


        [HttpGet]
        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else if(User.IsInRole("Power-User"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "PowerUser" });
                }

                //If Operations
                //If Teacher
                //If Sub-Teacher

            }

            return View();
        }
        


        
    }
}