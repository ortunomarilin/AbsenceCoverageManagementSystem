using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Areas.Admin.Models.ViewModels;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DataLayer.QueryOptions;
using AbsenceCoverageMS.Models.DataLayer.Repositories;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceCoverageMS.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AbsenceTypeController : Controller
    {
        private readonly UnitOfWork data;

        public AbsenceTypeController(AbsenceManagementContext ctx)
        {
            data = new UnitOfWork(ctx);
        }


        [HttpGet]
        public ViewResult List(FilterGridDTO values)
        {
            var gridBuilder = new AbsenceTypeGridBuilder(HttpContext.Session, values, nameof(AbsenceType.Name));

            var options = new AbsenceTypeQueryOptions
            {
                OrderByDirection = gridBuilder.CurrentGrid.SortDirection,
            };
            options.Search(gridBuilder);

            var model = new AbsenceTypeListViewModel
            {
                Grid = gridBuilder.CurrentGrid,
                AbsenceTypes = data.AbsenceTypes.List(options),
            };

            return View(model);
        }

        public RedirectToActionResult Search(string searchTerm, bool clear = false)
        {
            //Initialize with the GET constructor (Desirializes route dictionary to use and make changes.)
            var gridBuilder = new AbsenceTypeGridBuilder(HttpContext.Session);

            if (clear)
            {
                gridBuilder.ClearSearchOptions();
            }
            else
            {
                //Set new grid values and serialize. 
                gridBuilder.SetSearchOptions(searchTerm);
                gridBuilder.SerializeRoutes();
            }

            //Redirect to the List Action Method with updated grid.
            return RedirectToAction("List", gridBuilder.CurrentGrid);

        }






        [HttpGet]
        public ViewResult Add()
        {
            AbsenceTypeViewModel model = new AbsenceTypeViewModel();
            return View("AbsenceType", model);
        }


        [HttpPost]
        public IActionResult Add(AbsenceTypeViewModel model)
        {
            if(ModelState.IsValid)
            {
                AbsenceType absenceType = new AbsenceType
                {
                    Name = model.Name
                };

                data.AbsenceTypes.Insert(absenceType);
                data.Save();

                TempData["SucessMessage"] = "The Absence Type, " + model.Name + ", was created successfully.";
                return RedirectToAction("List");
            }

            return View("AbsenceType", model);
        }

        [HttpGet]
        public ViewResult Edit(string id)
        {
            AbsenceType absenceType = data.AbsenceTypes.Get(id);

            AbsenceTypeViewModel model = new AbsenceTypeViewModel 
            {
                AbsenceTypeId = absenceType.AbsenceTypeId,
                Name = absenceType.Name
            };

            return View("AbsenceType", model);
        }

        [HttpPost]
        public IActionResult Edit(AbsenceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                AbsenceType absenceType = new AbsenceType
                {
                    AbsenceTypeId = model.AbsenceTypeId,
                    Name = model.Name
                };

                data.AbsenceTypes.Update(absenceType);
                data.Save();

                TempData["SucessMessage"] = "The Absence Type with ID# " + model.AbsenceTypeId + ", was updated successfully.";
                return RedirectToAction("List");
            }

            return View("AbsenceType", model);
        }



        [HttpPost]
        public RedirectToActionResult Delete(string id)
        {
            AbsenceType absenceType = data.AbsenceTypes.Get(id);
            data.AbsenceTypes.Delete(absenceType);
            data.Save();

            TempData["SucessMessage"] = "The Absence Type, " + absenceType.Name + ", was deleted successfully.";
            return RedirectToAction("List");
        }



    }
}