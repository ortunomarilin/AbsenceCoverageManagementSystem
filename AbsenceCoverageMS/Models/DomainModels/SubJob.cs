using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class SubJob
    {
        public string SubJobId { get; set; }



        //Sub Job Produced by Absence Request
        public string AbsenceRequestId { get; set; }
        public string AbsenceRequest { get; set; }


        //Date of SubJob
        [Required(ErrorMessage = "The Date is required. ")]
        public DateTime Date { get; set; }


        //Sub Job For Period 
        public string PeriodId { get; set; }
        public Period Period { get; set; }


        //Assigned To / Accepted By 
        public string Id { get; set; }
        public User User { get; set; }






    }
}


