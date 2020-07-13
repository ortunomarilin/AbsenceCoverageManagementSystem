using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.SubTeacher.Models.ViewModels
{
    public class SubJobsAvailableViewModel
    {

        public GridDictionary Grid { get; set; }

        public IEnumerable<SubJob> AvailableSubJobs { get; set; }

        public IEnumerable<Campus> Campuses { get; set; }

        public IEnumerable<DurationType> DurationTypes { get; set; }



        //For Total number of pages
        public double TotalPages { get; set; }




    }
}
