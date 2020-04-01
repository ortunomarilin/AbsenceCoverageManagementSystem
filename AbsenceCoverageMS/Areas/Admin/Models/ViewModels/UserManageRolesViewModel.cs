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
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Checked { get; set; }


    }
}
