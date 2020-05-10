using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.Grid
{
    public class UserGridBuilder : GridBuilder
    {
        public UserGridBuilder(ISession s) : base(s)
        {

        }

        public UserGridBuilder(ISession s, UserGridDTO values, string defaultSort) : base(s, values, defaultSort)
        {
            //Inilialize routes
            grid.Campus = values.Campus;
            grid.Search = values.Search;

        }


        public void SetSearchOptions(string[] filters, string searchTerm)
        {
            //There is only 1 filter option (campus), so array will only have 1 value. 
            grid.Campus = filters[0];

            //The search property has no defual value, since it's optional. So, only change to lower if the search term has a value. 
            if(searchTerm != null)
            {
                grid.Search = searchTerm.ToLower();
            }  
        }


        public void ClearSearchOptions()
        {
            grid.Campus = "all";
            grid.Search = "";
        }





    }
}
