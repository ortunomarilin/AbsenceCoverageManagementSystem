using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AbsenceCoverageMS.Models.DomainModels.Enums;

namespace AbsenceCoverageMS.Models.ViewModels
{
    public class AbsenceViewModel
    {

        public AbsenceRequest AbsenceRequest { get; set; }


        
        [Required(ErrorMessage = "Please select if Need Coverage.")]
        public NeedCoverage? NeedCoverage { get; set; }



        //For the dropdown list of Absence Types 
        public List<AbsenceType> AbsenceTypes { get; set; } 



        //For the checklist of selectable periods. 
        public List<SelectablePeriodViewModel> SelectablePeriods { get; set; } 

    }
}
