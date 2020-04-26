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



        //Sub Job Produced by Absence Request
        public string AbsenceRequestId { get; set; }
        public AbsenceRequest AbsenceRequest { get; set; }


        //Date of SubJob
        [Required(ErrorMessage = "The Date is required. ")]
        public DateTime Date { get; set; }


        //Sub Job For Courese 
        public string CourseId { get; set; }
        public Course Course { get; set; }


        //Assigned To / Accepted By 
        public string UserId { get; set; }
        public User User { get; set; }






    }
}


