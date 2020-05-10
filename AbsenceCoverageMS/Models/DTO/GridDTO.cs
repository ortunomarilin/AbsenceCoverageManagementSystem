using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DTO
{
    public class GridDTO
    {

        //Sort grid parameters
        public string SortBy { get; set; }                     //  Specified at creation. 
        public string SortDirection { get; set; } = "asc";      // Has Default Value


        //Paging grid parameters
        public int PageNumber { get; set; } = 1;                // Has Default Value
        public int PageSize { get; set; } = 5;                  // Has Default Value
    }
}
