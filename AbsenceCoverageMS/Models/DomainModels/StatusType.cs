using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class StatusType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StatusTypeId { get; set; }

        public string Name { get; set; }


        public ICollection<AbsenceRequest> AbsenceRequests { get; set; }
        public ICollection<SubJob> SubJobs { get; set; }
    }
}
