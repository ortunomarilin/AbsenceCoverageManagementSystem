using AbsenceCoverageMS.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.Grid
{
    public class SubJobGridBuilder : GridBuilder
    {
        public SubJobGridBuilder(ISession s) : base(s)
        {

        }


        public SubJobGridBuilder(ISession s, FilterGridDTO values, string defaultSort) : base(s, values, defaultSort)
        {
            //Inilialize values
            grid.Campus = values.Campus;
            grid.Duration = values.Duration;

            SerializeRoutes();

        }

        //Method to set the Filter values for the Grid
        public void SetSearchOptions(string[] filters)
        {
            grid.Campus = filters[0];
            grid.Duration = filters[1];

            //After filtering set the current page to page-1 so you can start from beginning again. 
            grid.PageNumber = 1;

        }


        public void ClearSearchOptions()
        {
            grid.Campus = "all";
            grid.Duration = "all";
        }




    }
}
