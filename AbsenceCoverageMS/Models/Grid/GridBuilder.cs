using AbsenceCoverageMS.Models.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.Grid
{
    public class GridBuilder
    {

        //To key to use for serializing/desirializing route dictionary
        protected const string GridKey = "GridDictionary";

        //Protected so that derived clases can access this property only. 
        protected GridDictionary grid { get; set; }

        //To store current session.
        protected ISession session { get; set; }




        //Constructor to GET data from session
        public GridBuilder(ISession s)
        {
            //Save session
            session = s;

            //Deserialize AbsenceGridDictionary
            DeserializeRoutes();
        }



        //Constructor to SET the new route data and clear previous route
        public GridBuilder(ISession s, GridDTO values, string defaultSort)
        {
            //Save session
            session = s;

            //Clear any previous route
            grid = new GridDictionary();

            //Inilialize routes
            grid.SortBy = values.SortBy ?? defaultSort;  //If the property Sortby in GridDTO has no value apply the defaultSort field provided in constructor. 
            grid.SortDirection = values.SortDirection;
            grid.PageNumber = values.PageNumber;
            grid.PageSize = values.PageSize;

            SerializeRoutes();
        }




        //Public get only property used to get the value for the routeDictionary 
        public GridDictionary CurrentGrid => grid;





        //Method to serialize routeDictionary when done updating, to pass between sessions. 
        public void SerializeRoutes()
        {
            var dictionaryJson = JsonConvert.SerializeObject(grid);
            session.SetString(GridKey, dictionaryJson);
        }


        //Method to deserialize routeDictionary, and gain access to route values. 
        public void DeserializeRoutes()
        {
            var dictionaryJson = session.GetString(GridKey);
            grid = JsonConvert.DeserializeObject<GridDictionary>(dictionaryJson);
        }



        //Method to Get total pages for the grid. 
        public double GetTotalPages(int count)
        {
            int pageSize = grid.PageSize;

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
