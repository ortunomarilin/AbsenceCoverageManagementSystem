using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class CoveragePeriod
    {
        public string CoveragePeriodId { get; set; }

        public string Name { get; } = "Coverage";
       
        [Required]
        public string PeriodId { get; set; }
        public Period Period { get; set; }
        
        [Required]
        public PriorityType Priority { get; set; }
        
        public string Count { get; set; }
        
        [Required]
        public string Id { get; set; }
        public User User { get; set; }

    }
}

public enum PriorityType
{
    Primary,
    Secondary
}
