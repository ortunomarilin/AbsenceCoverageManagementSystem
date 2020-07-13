using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels
{
    public class CoverageAddSubJobViewModel
    {
        public string AbsenceRequestId { get; set; }

        public SubJob SubJob { get; set; }


        public IEnumerable<DurationType> DurationTypes { get; set; }



    }
}
