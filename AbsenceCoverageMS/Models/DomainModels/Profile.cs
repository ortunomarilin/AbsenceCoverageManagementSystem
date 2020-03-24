using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Profile
    {
        public string ProfileId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }


        public string Position { get; set; }

        public string TeachingSubjects { get; set; }

        
        public string CampusId { get; set; }  //FK
        public Campus Campus { get; set; }    //Nav
       

        //1 to 1 => This the Dependent 
        public string Id { get; set; }       //FK
        public User User { get; set; }      //Nav
    }
}
