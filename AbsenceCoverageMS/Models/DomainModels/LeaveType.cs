using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class LeaveType
    {
        public string LeaveTypeId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public ICollection<AbsenceBalance> AbsenceBalances { get; set; }
    }
}


