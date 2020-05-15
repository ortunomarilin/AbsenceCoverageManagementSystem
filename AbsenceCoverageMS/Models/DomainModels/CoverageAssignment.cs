using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class CoverageAssignment
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CoverageAssignmentId { get; set; }


        //Instructions to Sub-Teacher 
        public string  TeacherInstructions { get; set; }


        //Assignment belongs to SubJob
        public string SubJobId { get; set; }
        public SubJob SubJob { get; set; }


        //Assignment to cover period
        public string PeriodId { get; set; }
        public Period Period { get; set; }


        //Assignment Assigned / Accepted by
        public string UserId { get; set; }
        public User User { get; set; }


        //Assignment status (Filled / Unfilled)
        public string StatusTypeId { get; set; }
        public StatusType StatusType { get; set; }


    }
}
