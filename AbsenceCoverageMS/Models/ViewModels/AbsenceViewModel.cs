using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AbsenceCoverageMS.Models.ViewModels
{
    public class AbsenceViewModel
    {

        public AbsenceRequest AbsenceRequest { get; set; }



        [Required(ErrorMessage = "Please select if Need Coverage.")]
        public string NeedCoverageInput { get; set; }



        //For the dropdown lists 
        public IEnumerable<AbsenceType> AbsenceTypes { get; set; }

        public IEnumerable<DurationType> DurationTypes { get; set; }



        //For the checklist of selectable periods. 
        public List<SelectablePeriodViewModel> SelectablePeriods { get; set; } 

    }
}
