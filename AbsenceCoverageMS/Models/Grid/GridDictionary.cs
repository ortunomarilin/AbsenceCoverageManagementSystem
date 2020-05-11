using AbsenceCoverageMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            get => Get(nameof(UserGridDTO.Search));
            set => this[nameof(UserGridDTO.Search)] = value;
        }


        //Date Search parameters
        public string FromDate
        {
            get => Get(nameof(AbsenceGridDTO.FromDate))?.Replace("-", "/");
            set => this[nameof(AbsenceGridDTO.FromDate)] = value?.Replace("/", "-");
        }

        public string ToDate
        {
            get => Get(nameof(AbsenceGridDTO.ToDate))?.Replace("-", "/");
            set => this[nameof(AbsenceGridDTO.ToDate)] = value?.Replace("/", "-");
        }



        //Filter Parameters 
        public string Campus
        {
            get => Get(nameof(UserGridDTO.Campus));
            set => this[nameof(UserGridDTO.Campus)] = value;
        }


        public string AbsenceType
        {
            get => Get(nameof(AbsenceGridDTO.AbsenceType));
            set => this[nameof(AbsenceGridDTO.AbsenceType)] = value;
        }


        public string Duration
        {
            get => Get(nameof(AbsenceGridDTO.Duration));
            set => this[nameof(AbsenceGridDTO.Duration)] = value;
        }

        public string NeedCoverage
        {
            get => Get(nameof(AbsenceGridDTO.NeedCoverage));
            set => this[nameof(AbsenceGridDTO.NeedCoverage)] = value;
        }


        public string Status
        {
            get => Get(nameof(AbsenceGridDTO.Status));
            set => this[nameof(AbsenceGridDTO.Status)] = value;
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
