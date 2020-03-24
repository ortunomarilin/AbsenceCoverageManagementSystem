using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class SubJob
    {
        public string SubJobId { get; set; }

        //Accpeted By Sub
        public string Id { get; set; }
        public User User { get; set; }


        //Sub Job for Absence Request
        [Required]
        public string AbsenceRequestId { get; set; }
        public string AbsenceRequest { get; set; }

        
        //Status of Job
        public SubJobStatus Status { get; set; }

        public ICollection<EmergencyCoverage> EmergencyCoverages { get; set; }
    }
}

public enum SubJobStatus
{
    Open,
    Closed
}
