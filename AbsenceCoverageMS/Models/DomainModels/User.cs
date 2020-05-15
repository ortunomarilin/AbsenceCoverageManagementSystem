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

        [Required(ErrorMessage = "First Name required.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name required.")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Position Title required.")]
        public string PositionTitle { get; set; }




        //User is Employee of Campus 
        [Required(ErrorMessage = "Campus required.")]
        public string CampusId { get; set; }   //Fk
        public Campus Campus { get; set; }     //Nav



        //Has Coverage Period
        public CoveragePeriod CoveragePeriod { get; set; } //Nav



        //Submitted Absence Requests
        public ICollection<AbsenceRequest> AbsenceRequests { get; set; }

        //Assigned CoverageAssignments
        public ICollection<CoverageAssignment> CoverageAssignments { get; set; }



        //Method
        public string FullName => $"{FirstName} {LastName}";


    }
}
