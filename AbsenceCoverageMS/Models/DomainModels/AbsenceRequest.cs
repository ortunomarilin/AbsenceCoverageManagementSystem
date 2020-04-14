using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceRequest
    {
        public string AbsenceRequestId { get; set; }


        //Requested By
        [Required(ErrorMessage = "Requested by required.")]
        public string Id { get; set; }
        public User User { get; set; }


        [Required(ErrorMessage = "Date of Submission is required.")]
        public DateTime DateSubmitted { get; set; }


        [Required(ErrorMessage = "Absence Type is required.")]
        public string AbsenceTypeId { get; set; }
        public AbsenceType Type { get; set; }


        //Date Range 
        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { get; set; }


        //Time Range 
        [Required(ErrorMessage = "Start Time is required.")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End Time is required.")]
        public DateTime EndTime { get; set; }


        //Full or Half Day 
        [Required(ErrorMessage = "Please select a duration.")]
        public Duration Duration { get; set; }



        [Required(ErrorMessage = "Please select if coverage is needed.")]
        public bool NeedCoverage { get; set; }


        public ICollection<AbsenceRequestPeriod> PeriodsNeedCoverage { get; set; }


        //Status 
        public Status Status { get; set; }
        public string StatusRemarks { get; set; }
        public DateTime DateProcessed { get; set; }


        //Produces SubJobs
        public ICollection<SubJob> SubJobs { get; set; }  //Nav


    }
}

public enum Status
{
    Submitted,
    Approved,
    Denied,
    Cancelled
}

public enum Duration
{
    FullDay,
    HalfDay
}
