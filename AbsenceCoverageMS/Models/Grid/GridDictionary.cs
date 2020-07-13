/// <summary>
/// This class is responsible for storing all grid values for paging, sorting, and filtering. 
/// This class will be stored whithin a session state. 
/// </summary>
/// 

using AbsenceCoverageMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsenceCoverageMS.Models.Grid
{
    public class GridDictionary : Dictionary<string, string>
    {

        //Sort parameters
        public string SortBy
        {
            get => Get(nameof(GridDTO.SortBy));
            set => this[nameof(GridDTO.SortBy)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }



        //Paging parameters 
        public int PageNumber
        {
            get
            {
                int.TryParse(Get(nameof(GridDTO.PageNumber)), out int number);
                return number;
            }
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }


        public int PageSize
        {
            get
            {
                int.TryParse(Get(nameof(GridDTO.PageSize)), out int number);
                return number;
            }
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }


        //Search parameter
        public string Search
        {
            get => Get(nameof(FilterGridDTO.Search));
            set => this[nameof(FilterGridDTO.Search)] = value;
        }


        //Date Search parameters
        public string FromDate
        {
            get => Get(nameof(FilterGridDTO.FromDate))?.Replace("-", "/");
            set => this[nameof(FilterGridDTO.FromDate)] = value?.Replace("/", "-");
        }

        public string ToDate
        {
            get => Get(nameof(FilterGridDTO.ToDate))?.Replace("-", "/");
            set => this[nameof(FilterGridDTO.ToDate)] = value?.Replace("/", "-");
        }



        //Filter Parameters 
        public string Campus
        {
            get => Get(nameof(FilterGridDTO.Campus));
            set => this[nameof(FilterGridDTO.Campus)] = value;
        }


        public string AbsenceType
        {
            get => Get(nameof(FilterGridDTO.AbsenceType));
            set => this[nameof(FilterGridDTO.AbsenceType)] = value;
        }


        public string Duration
        {
            get => Get(nameof(FilterGridDTO.Duration));
            set => this[nameof(FilterGridDTO.Duration)] = value;
        }

        public string NeedCoverage
        {
            get => Get(nameof(FilterGridDTO.NeedCoverage));
            set => this[nameof(FilterGridDTO.NeedCoverage)] = value;
        }


        public string AbsenceStatus
        {
            get => Get(nameof(FilterGridDTO.AbsenceStatus));
            set => this[nameof(FilterGridDTO.AbsenceStatus)] = value;
        }



        public string SubJobStatus
        {
            get => Get(nameof(FilterGridDTO.SubJobStatus));
            set => this[nameof(FilterGridDTO.SubJobStatus)] = value;
        }


        //All getters will call this method to check if there is a value in the key with name given, and reutrn the value if any. 
        private string Get(string key) => Keys.Contains(key) ? this[key] : null;




        public string GetNewSortDirection(string newSortBy)
        {
            string newSortDirection; 

            if (newSortBy == SortBy)
            {
                newSortDirection = SortDirection == "asc" ? "desc" : "asc";
                return newSortDirection;

            }
            else
            {
                newSortDirection = "asc";
                return newSortDirection;
            }
        }


    }
}
