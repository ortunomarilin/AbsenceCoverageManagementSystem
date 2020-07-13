using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class AbsenceTypeViewModel
    {
        public string AbsenceTypeId { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
