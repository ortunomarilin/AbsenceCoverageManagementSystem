using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        [Required]
        public string Position { get; set; }

        public string TeachingSubjects { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }


        //For the select dropdown. 
        [Required(ErrorMessage = "Campus name required")]
        public string CampusId { get; set; }

        //For the dropdown of campus options. 
        public IEnumerable<Campus> Campuses { get; set; } = new List<Campus>();


    }
}
