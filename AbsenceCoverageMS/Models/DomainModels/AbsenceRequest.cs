using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceRequest
    {
        public string AbsenceRequestId { get; set; }
        
        [Required]
        public string Id { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public LeaveType Type { get; set; }
        
        public string RequestorComments { get; set; }
        
        [Required]
        public bool NeedCoverage { get; set; }
        public string SubJobId { get; set; }

        
        public DateTime DateSubmitted { get; set; }
        public int Duration { get; set; }

    }
}
