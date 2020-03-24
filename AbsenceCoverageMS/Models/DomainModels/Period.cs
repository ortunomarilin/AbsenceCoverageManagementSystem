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
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<CoveragePeriod> CoveragePeriods { get; set; }
    }
}


