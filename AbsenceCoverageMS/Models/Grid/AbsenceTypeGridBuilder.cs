using AbsenceCoverageMS.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.Grid
{
    public class AbsenceTypeGridBuilder : GridBuilder
    {
        //Constructor to GET data from session
        public AbsenceTypeGridBuilder(ISession s) : base(s)
        {

        }

        public AbsenceTypeGridBuilder(ISession s, FilterGridDTO values, string defaultSort) : base(s, values, defaultSort)
        {
            //Inilialize values
            grid.Search = values.Search;

            SerializeRoutes();
        }



        //Method to set the Filter values for the Grid
        public void SetSearchOptions(string searchTerm)
        {
            //The search property has no defual value, since it's optional. So, only save and change to lower if the search term has a value. 
            if (searchTerm != null)
            {
                grid.Search = searchTerm.ToLower();
            }

        }



        public void ClearSearchOptions()
        {
            grid.Search = "";
        }
    }
}
