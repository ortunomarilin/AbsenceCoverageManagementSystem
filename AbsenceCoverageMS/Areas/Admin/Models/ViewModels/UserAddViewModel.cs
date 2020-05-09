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

        public string UserId { get; set; }


        [Required(ErrorMessage = "Please provide a First Name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please provide a Last Name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please provide a Position Title.")]
        [Display(Name = "Position Title")]
        public string PositionTitle { get; set; }


        [Required(ErrorMessage = "Please provide a Phone number.")]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Invalid Phone Number - Please enter a valid phone number.")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please provide an Email address.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid Email - Please enter a valid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please select a Campus.")]
        public string CampusId { get; set; }



        public string RoleId { get; set; }



        [Required(ErrorMessage = "Please provide a Username.")]
        public string Username { get; set; }



        [Required(ErrorMessage = "Please provide a Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password entries do not match.")]
        public string confirmPassword { get; set; }



        //Dropdown Lists 
        public IEnumerable<Campus> Campuses { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
