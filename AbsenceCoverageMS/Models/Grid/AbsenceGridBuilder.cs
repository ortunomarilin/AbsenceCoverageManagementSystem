using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AbsenceCoverageMS.Models.DTO;
using Microsoft.AspNetCore.Routing;
using System.Globalization;

namespace AbsenceCoverageMS.Models.Grid
{
    public class AbsenceGridBuilder
    {

        private const string Key = "routeDictionary";
        private AbsenceGridRouteDictionary route { get; set; }
        private ISession session { get; set; }



        //Constructor to SET the new route data and clear previous route
        public AbsenceGridBuilder(ISession s, AbsenceGridDTO parameters)
        {
            //Save session
            session = s;

            //Clear any previous route
            route = new AbsenceGridRouteDictionary();

            //Inilialize routes
            route.AbsenceType = parameters.AbsenceType;
            route.Duration = parameters.Duration;
            route.NeedCoverage = parameters.NeedCoverage;
            route.Status = parameters.Status;
            route.SortBy = parameters.SortBy;
            route.SortDirection = parameters.SortDirection;
            route.PageNumber = parameters.PageNumber;
            route.PageSize = parameters.PageSize;
            route.FromDate = parameters.FromDate;
            route.ToDate = parameters.ToDate;


            //Serialize new route (save) 
            SerializeRoutes();
        }



        //Constructor to GET data from session
        public AbsenceGridBuilder(ISession s)
        {
            //Save session
            session = s;

            //Deserialize AbsenceGridRouteDictionary
            DeserializeRoutes();
        }



        //Public get only property used to get the private value for the routeDictionary 
        public AbsenceGridRouteDictionary GetCurrentRoute => route;




        //Method to serialize routeDictionary when done updating, to pass between sessions. 
        public void SerializeRoutes()
        {
            var dictionaryJson = JsonConvert.SerializeObject(route);
            session.SetString(Key, dictionaryJson);
        }



        //Method to deserialize routeDictionary, and gain access to route values. 
        public void DeserializeRoutes()
        {
            var dictionaryJson = session.GetString(Key);
            route = JsonConvert.DeserializeObject<AbsenceGridRouteDictionary>(dictionaryJson);
        }



        //Method to set the Filter values for the Grid
        public void ReSetFilters(string[] filters, string fromdate, string todate)
        {
            route.AbsenceType = filters[0];
            route.Duration = filters[1];
            route.NeedCoverage = filters[2];
            route.Status = filters[3];


            //If only start date input is given, and is valid. 
            if(IsValidDate(fromdate) && todate == null)
            {
                route.FromDate = fromdate;
                route.ToDate = fromdate;
            }
            //If only end date input is given, and is valid. 
            else if (IsValidDate(todate) && fromdate == null)
            {
                route.FromDate = todate;
                route.ToDate = todate;
            }
            //If both start date and end date is given, and valid.
            else if (IsValidDate(fromdate) && IsValidDate(todate))
            {
                route.FromDate = fromdate;
                route.ToDate = todate;
            }
            else
            {
                route.FromDate = null;
                route.ToDate = null;
            }

            //After filtering set the current page to page-1 so you can start from beginning again. 
            route.PageNumber = 1;
        }



        //Method to Get total pages for the grid. 
        public double GetTotalPages(int count)
        {
            int pageSize = route.PageSize;

            double total = (count + pageSize - 1) / pageSize;
            total = Math.Ceiling(total);

            return total;
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




    }
}
