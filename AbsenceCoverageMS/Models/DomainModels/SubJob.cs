using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class SubJob
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SubJobId { get; set; }



        //Date Range 
        [Required(ErrorMessage = "Please select a Start Date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }


        [Required(ErrorMessage = "Please select an End Date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }




        //Time Range 
        [Required(ErrorMessage = "Please select a Start Time.")]
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }


        [Required(ErrorMessage = "Please select an End Time.")]
        [DataType(DataType.Time)]
        public DateTime? EndTime { get; set; }



        //Full or Half Day 
        [Required(ErrorMessage = "Please select a duration.")]
        public string DurationTypeId { get; set; }
        public DurationType DurationType { get; set; }



        public string TeacherInstructions { get; set; }



        public string UserId { get; set; }
        public User User { get; set; }



        //Filled or Unfilled
        public string SubJobStatusId { get; set; }
        public SubJobStatus SubJobStatus { get; set; }



        public string AbsenceRequestId { get; set; }
        public AbsenceRequest AbsenceRequest { get; set; }




    }
}
