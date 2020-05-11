using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DTO
{
    public class AbsenceGridDTO : GridDTO
    {

        public string Search { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }



        //Filter Route parameters 
        public string AbsenceType { get; set; } = "all";         // Has Default Value
        public string Duration { get; set; } = "all";           // Has Default Value
        public string Status { get; set; } = "all";             // Has Default Value
        public string NeedCoverage { get; set; } = "all";



    }
}
