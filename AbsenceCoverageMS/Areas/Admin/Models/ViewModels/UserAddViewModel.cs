using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class UserAddViewModel
    {

        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        [Required]
        public string PositionTitle { get; set; }

        public string TeachingSubjects { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password entries do not match.")]
        public string confirmPassword { get; set; }



        //For the dropdown of campus options. 
        [Required(ErrorMessage = "Campus Name required") ]
        public string CampusId { get; set; }

        public List<Campus> Campuses { get; set; } = new List<Campus>();



        //For the dropdown of roles. 
        public string Id { get; set; }
        public List<IdentityRole> AvailableRoles { get; set; } = new List<IdentityRole>();





    }
}
