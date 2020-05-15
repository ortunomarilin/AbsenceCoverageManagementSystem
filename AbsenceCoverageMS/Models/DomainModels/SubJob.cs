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


        //SubJob Status (Filled / Unfilled) 
        public string StatusTypeId { get; set; }
        public StatusType StatusType { get; set; }


        //Hs coverage assignments
        public ICollection<CoverageAssignment> CoverageAssignments { get; set; }




    }
}


