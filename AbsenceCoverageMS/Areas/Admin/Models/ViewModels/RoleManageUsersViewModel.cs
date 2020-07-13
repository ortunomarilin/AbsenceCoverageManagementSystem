using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class RoleManageUsersViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public List<User> RoleUsers { get; set; } = new List<User>();


        public string UserId { get; set; }
        public List<User> AvailableUsers { get; set; } = new List<User>();
    }
}
