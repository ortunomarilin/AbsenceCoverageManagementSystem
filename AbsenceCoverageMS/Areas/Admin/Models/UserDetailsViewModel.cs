using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models
{
    public class UserDetailsViewModel
    {
        
        public string Action { get; set; }

        public string buttonState { get; set; }
        public string inputState { get; set; }



        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        [Required]
        public string Position { get; set; }


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


        //RoleId
        public string Id { get; set; }

        //For the Items list box.
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();


        [Required]
        public string CampusId { get; set; }

        //For the dropdown of campus options. 
        public IEnumerable<Campus> Campuses { get; set; } = new List<Campus>();



        public void State(string action)
        {
            if(action == "Edit")
            {
                buttonState = "Active";
                inputState = "";
            }
            else
            {
                buttonState = "Disabled";
                inputState = "readonly";
            }
            

        }



    }
}
