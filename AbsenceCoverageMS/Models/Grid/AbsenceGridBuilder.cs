using Microsoft.AspNetCore.Http;
using System;
using AbsenceCoverageMS.Models.DTO;
using System.Globalization;


namespace AbsenceCoverageMS.Models.Grid
{
    public class AbsenceGridBuilder : GridBuilder
    {

        //Constructor to GET data from session
        public AbsenceGridBuilder(ISession s) : base(s)
        {
            
        }

        public AbsenceGridBuilder(ISession s, FilterGridDTO values, string defaultSort) : base(s, values, defaultSort)
        {
            //Inilialize values
            grid.AbsenceType = values.AbsenceType;
            grid.Duration = values.Duration;
            grid.NeedCoverage = values.NeedCoverage;
            grid.Status = values.Status;
            grid.FromDate = values.FromDate;
            grid.ToDate = values.ToDate;
            grid.Search = values.Search;

            SerializeRoutes();
        }



        //Method to set the Filter values for the Grid
        public void SetSearchOptions(string[] filters, string fromdate, string todate, string searchTerm)
        {
            grid.AbsenceType = filters[0];
            grid.Duration = filters[1];
            grid.NeedCoverage = filters[2];
            grid.Status = filters[3];

            //The search property has no defual value, since it's optional. So, only save and change to lower if the search term has a value. 
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




        //Method to help validate the string date. 
        public bool IsValidDate(string stringDate)
        {
            string validformat = "MM/dd/yyyy";
            DateTime DateTimeDate;

            if (DateTime.TryParseExact(stringDate, validformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeDate))
            {
                return true;
            }
            else
            {
                //Invalid Date input. 
                return false;
            }
        }

        public DateTime ConvertToDateTime(string stringDate)
        {
            string validformat = "MM/dd/yyyy";
            DateTime DateTimeDate;

            DateTime.TryParseExact(stringDate, validformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeDate);
            return DateTimeDate;
        }


        public void ClearSearchOptions()
        {
            grid.AbsenceType = "all";
            grid.Duration = "all";
            grid.NeedCoverage = "all";
            grid.Status = "all";
            grid.FromDate = "";
            grid.ToDate = "";
            grid.Search = "";
        }




    }
}
