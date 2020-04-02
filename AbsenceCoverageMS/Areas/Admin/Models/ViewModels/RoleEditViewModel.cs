using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class RoleEditViewModel
    {
        public string RoleId { get; set; }

        [Required(ErrorMessage = "The Role name is required.")]
        public string RoleName { get; set; }
    }
}
