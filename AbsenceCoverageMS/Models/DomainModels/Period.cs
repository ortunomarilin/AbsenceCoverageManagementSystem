using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Period
    {
        public string PeriodId { get; set; }


        [Required(ErrorMessage ="The Period Number is required.")]
        public int PeriodNumber { get; set; }

        [Required(ErrorMessage = "Period Number is required. ")]
        public string Name { get; set; }


        public ICollection<Course> Courses { get; set; }
        public ICollection<CoveragePeriod> CoveragePeriods { get; set; }


        public ICollection<AbsenceRequestPeriod> AbsenceRequestPeriods { get; set; }
        public ICollection<SubJob> SubJobs { get; set; }

    }
}


