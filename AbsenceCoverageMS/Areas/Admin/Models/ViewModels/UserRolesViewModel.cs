using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PositionTitle { get; set; }


        public string RoleId { get; set; }

        public List<IdentityRole> UserRoles { get; set; } = new List<IdentityRole>();
        public IEnumerable<IdentityRole> AvailableRoles { get; set; }
    }
}
