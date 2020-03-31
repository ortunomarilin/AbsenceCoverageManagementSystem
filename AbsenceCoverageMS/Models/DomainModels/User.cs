using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class User : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Position { get; set; }

        public string TeachingSubjects { get; set; }


        //User is Employee of Campus 
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


        //Method
        public string FullName => $"{FirstName} {LastName}";

    }
}
