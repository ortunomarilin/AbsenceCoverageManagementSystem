using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class EmergencyCoverage
    {
        public string EmergencyCoverageId { get; set; }

        //For Sub Job
        [Required]
        public string SubJobId { get; set; }
        
        //On Date
        [Required]
        public DateTime Date { get; set; }

        //Assigned To
        public string Id { get; set; }
        public User User { get; set; }
    }
}
