using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class UserManageRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public List<IdentityRole> UsersRoles { get; set; } = new List<IdentityRole>();


        public string Id { get; set; }
        public List<IdentityRole> AvailableRoles { get; set; } = new List<IdentityRole>();


    }
}
