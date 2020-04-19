using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AbsenceCoverageMS.Models.DomainModels.Enums;

namespace AbsenceCoverageMS.Models.ViewModels
{
    public class AbsenceRequestViewModel
    {
        public string AbsenceRequestId { get; set; }

        //DropDown AbsenceType List 
        [Required(ErrorMessage = "* Please select an Absence Type.")]
        public string AbsenceTypeId { get; set; }
        public List<AbsenceType> AbsenceTypes { get; set; } = new List<AbsenceType>();



        //Date Range 
        [Required (ErrorMessage ="* Please select a Start Date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[RegularExpression(@"^(?:^(?:(?:(?:(?:(?:0[13578]|1[02])/31)|(?:(?:0[13-9]|1[0-2])/(?:29|30)))/(?:1[6-9]|[2-9]\d)\d{2})|(?:02/29/(?:(?:(?:1[6-9]|[2-9]\d)(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0[1-9])|(?:1[0-2]))/(?:0[1-9]|1\d|2[0-8])/(?:(?:1[6-9]|[2-9]\d)\d{2}))$)$", ErrorMessage ="* Invalid Start Date" )]
        public DateTime? StartDate { get; set; }


        [Required(ErrorMessage = "* Please select an End Date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }



        //Time Range 
        [Required(ErrorMessage = "* Please select a Start Time.")]
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }


        [Required(ErrorMessage = "* Please select an End Time.")]
        [DataType(DataType.Time)]
        public DateTime? EndTime { get; set; }



        //Full or Half Day 
        [Required (ErrorMessage ="* Please select a Duration.")]
        public Duration? Duration { get; set; }
        

        [Required(ErrorMessage = "* Please select if Need Coverage.")]
        public NeedCoverage? NeedCoverage { get; set; }


        //For CheckList of Periods need sub.  
        public string PeriodId { get; set; }
        public List<SelectablePeriodViewModel> SelectablePeriods { get; set; }
       

        //Status 
        public Status Status { get; set; }
    }
}


