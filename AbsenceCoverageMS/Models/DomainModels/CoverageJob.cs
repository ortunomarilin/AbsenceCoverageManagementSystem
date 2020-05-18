using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class CoverageJob
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CoverageJobId { get; set; }



        [Required(ErrorMessage = "Please select a Date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date { get; set; }



        [Required(ErrorMessage = "Please select a Period.")]
        public string PeriodId { get; set; }
        public Period Period { get; set; }



        public string TeacherInstructions { get; set; }



        [Required(ErrorMessage = "Please select a Teacher to assign this coverage.")]
        public string UserId { get; set; }
        public User User { get; set; }



        //Filled or Unfilled
        public string CoverageStatusTypeId { get; set; }
        public CoverageStatusType CoverageStatusType { get; set; }



        public string AbsenceRequestId { get; set; }
        public AbsenceRequest AbsenceRequest { get; set; }




    }
}
