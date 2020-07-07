using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.SubTeacher.Models.ViewModels
{
    public class SubJobsHistoryViewModel
    {
        public GridDictionary Grid { get; set; }

        public IEnumerable<SubJob> SubJobs { get; set; }

        public IEnumerable<Campus> Campuses { get; set; }

        public IEnumerable<DurationType> DurationTypes { get; set; }



        //For Total number of pages
        public double TotalPages { get; set; }

    }
}
