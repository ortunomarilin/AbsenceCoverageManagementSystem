using AbsenceCoverageMS.Models.DataLayer.SeedData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AbsenceRequestId { get; set; }


        //Requested By User 
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }


        //Date Submitted
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateSubmitted { get; set; }



        //Absence Type 
        [Required(ErrorMessage = "Please select an Absence Type.")]
        public string AbsenceTypeId { get; set; }
        public AbsenceType AbsenceType { get; set; }



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
        



        [Required(ErrorMessage = "Please select if coverage is needed.")]
        public bool NeedCoverage { get; set; }

        public ICollection<AbsenceRequestPeriod> AbsenceRequestPeriods { get; set; }

        //Produces SubJobs
        public ICollection<SubJob> SubJobs { get; set; }  //Nav




        //Status 
        public string StatusTypeId { get; set; }
        public StatusType StatusType { get; set; }


        public string StatusRemarks { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateProcessed { get; set; }


    }
}








