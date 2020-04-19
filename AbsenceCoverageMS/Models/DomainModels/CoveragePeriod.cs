using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class CoveragePeriod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CoveragePeriodId { get; set; }

       
        public string Name { get; } = "Coverage";


        [Required(ErrorMessage = "A Period number is required. ")]
        public string PeriodId { get; set; }
        public Period Period { get; set; }


        [Required(ErrorMessage = "Priority is required. ")]
        public PriorityType Priority { get; set; }
        

        public string Count { get; set; }


        [Required(ErrorMessage = "A Teacher Name is required. ")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}

public enum PriorityType
{
    Primary,
    Secondary
}
