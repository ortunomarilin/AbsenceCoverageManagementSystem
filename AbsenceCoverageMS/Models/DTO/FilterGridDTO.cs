/// <summary>
/// This class is responsible for binding the Filter values to Action Method parameters for Grid creation.
/// This class also inherits values from the GridDTO class to bind Paging and Sorting values to Action Method parameters for Grid creation.
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DTO
{
    public class FilterGridDTO : GridDTO
    {

        public string Search { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }



        //Filter Route parameters 
        public string AbsenceType { get; set; } = "all";         
        public string Duration { get; set; } = "all";          
        public string AbsenceStatus { get; set; } = "all";             
        public string NeedCoverage { get; set; } = "all";
        public string Campus { get; set; } = "all";

        public string SubJobStatus { get; set; } = "all";
        public string CoverageJobStatus { get; set; } = "all";

    }
}
