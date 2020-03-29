using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models
{
    public class EditRoleViewModel
    {
        public string id { get; set; }

        [Required(ErrorMessage = "Role Name - Required.")]
        public string RoleName { get; set; }

        public List<User> roleUsers { get; set; } = new List<User>();
    }
}
