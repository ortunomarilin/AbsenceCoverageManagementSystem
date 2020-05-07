using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DTO
{
    public class AbsenceGridDTO
    {    
        public string FromDate { get; set; }
        public string ToDate { get; set; }



        //Filter Route parameters 
        public string AbsenceType { get; set; } = "all";         // Has Default Value
        public string Duration { get; set; } = "all";           // Has Default Value
        public string Status { get; set; } = "all";             // Has Default Value
        public string NeedCoverage { get; set; } = "all";


        //Sort Route parameters
        public string SortBy { get; set; } = "date";             // Has Default Value
        public string SortDirection { get; set; } = "desc";      // Has Default Value


        //Paging 
        public int PageNumber { get; set; } = 1;                // Has Default Value
        public int PageSize { get; set; } = 5;                  // Has Default Value

    }
}
