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

        [Required(ErrorMessage = "First Name required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Position Title is required.")]
        public string PositionTitle { get; set; }

        [Required(ErrorMessage = "* A Phone Number is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "An Email address is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Username is required.")]
        public string Username { get; set; }


        //For the select dropdown. 
        [Required(ErrorMessage = "A Campus name required.")]
        public string CampusId { get; set; }

        //For the dropdown of campus options. 
        public IEnumerable<Campus> Campuses { get; set; } = new List<Campus>();


    }
}
