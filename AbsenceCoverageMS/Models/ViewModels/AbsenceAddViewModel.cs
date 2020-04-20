using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AbsenceCoverageMS.Models.DomainModels.Enums;

namespace AbsenceCoverageMS.Models.ViewModels
{
    public class AbsenceAddViewModel
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


