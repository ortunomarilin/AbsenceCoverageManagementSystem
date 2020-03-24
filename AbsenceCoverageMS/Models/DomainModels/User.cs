using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class User : IdentityUser
    {

        public string ProfileId { get; set; }  //FK


        //User is Manager of Campus 
        public string CampusId { get; set; }   //Fk
        public Campus Campus { get; set; }     //Nav
        
       
        //Has Coverage Period
        public string CoveragePeriodId { get; set; } //FK
        
        
        //Teaches Courses 
        public ICollection<Course> Courses { get; set; }

        //Has Absence Balances
        public ICollection<AbsenceBalance> AbsenceBalances { get; set; }
        
        //Submitted Absence Requests
        public ICollection<AbsenceRequest> AbsenceRequests { get; set; }

        //Accepted SubJobs
        public ICollection<SubJob> SubJobs { get; set; }

        //Assigned Emergency Coverage during coverage period. 
        public ICollection<EmergencyCoverage> EmergencyCoverages { get; set; }


        [NotMapped]
        public IList<string> RoleNames { get; set; }

    }
}
