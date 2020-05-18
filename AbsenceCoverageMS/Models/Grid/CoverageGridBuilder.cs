using AbsenceCoverageMS.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.Grid
{
    public class CoverageGridBuilder : GridBuilder
    {
        public CoverageGridBuilder(ISession s) : base(s)
        {

        }

        public CoverageGridBuilder(ISession s, FilterGridDTO values, string defaultSort) : base(s, values, defaultSort)
        {
            //Inilialize values
            grid.Search = values.Search;
            grid.FromDate = values.FromDate;
            grid.ToDate = values.ToDate;
            grid.Duration = values.Duration;
            grid.SubJobStatus = values.SubJobStatus;
            grid.CoverageJobStatus = values.CoverageJobStatus;


            SerializeRoutes();

        }

        //Method to set the Filter values for the Grid
        public void SetSearchOptions(string[] filters, string fromdate, string todate, string searchTerm)
        {
            grid.Duration = filters[0];
            grid.SubJobStatus = filters[1];
            grid.CoverageJobStatus = filters[2];


            if (searchTerm != null)
            {
                grid.Search = searchTerm.ToLower();
            }



            //If only start date input is given, and is valid. 
            if (IsValidDate(fromdate) && todate == null)
            {
                grid.FromDate = fromdate;
                grid.ToDate = fromdate;
            }
            //If only end date input is given, and is valid. 
            else if (IsValidDate(todate) && fromdate == null)
            {
                grid.FromDate = todate;
                grid.ToDate = todate;
            }
            //If both start date and end date is given, and valid.
            else if (IsValidDate(fromdate) && IsValidDate(todate))
            {
                grid.FromDate = fromdate;
                grid.ToDate = todate;
            }


            //After filtering set the current page to page-1 so you can start from beginning again. 
            grid.PageNumber = 1;
        }


        public void ClearSearchOptions()
        {
            grid.Duration = "all";
            grid.SubJobStatus = "all";
            grid.CoverageJobStatus = "all";
            grid.FromDate = "";
            grid.ToDate = "";
            grid.Search = "";
        }

    }
}
