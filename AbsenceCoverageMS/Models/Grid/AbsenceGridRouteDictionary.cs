using AbsenceCoverageMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.Grid
{
    public class AbsenceGridDictionary : Dictionary<string, string>
    {

        //Filter Route Keys 
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




        //Sort Route parameters
        public string SortBy
        {
            get => Get(nameof(AbsenceGridDTO.SortBy));
            set => this[nameof(AbsenceGridDTO.SortBy)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(AbsenceGridDTO.SortDirection));
            set => this[nameof(AbsenceGridDTO.SortDirection)] = value;
        }



        //Paging parameters 
        public int PageNumber
        {
            get 
            {
                int.TryParse(Get(nameof(AbsenceGridDTO.PageNumber)), out int number);
                return number;
            }
            set => this[nameof(AbsenceGridDTO.PageNumber)] = value.ToString();
        }


        public int PageSize
        {
            get
            {
                int.TryParse(Get(nameof(AbsenceGridDTO.PageSize)), out int number);
                return number;
            }
            set => this[nameof(AbsenceGridDTO.PageSize)] = value.ToString();
        }

        public string FromDate
        {
            get => Get(nameof(AbsenceGridDTO.FromDate))?.Replace("-","/");
            set => this[nameof(AbsenceGridDTO.FromDate)] = value?.Replace("/","-");
        }

        public string ToDate
        {
            get => Get(nameof(AbsenceGridDTO.ToDate))?.Replace("-","/");
            set => this[nameof(AbsenceGridDTO.ToDate)] = value?.Replace("/", "-");
        }




        //All getters will call this method to check if there is a value in the key with name given, and reutrn the value if any. Else it will return null.  
        private string Get(string key) => Keys.Contains(key) ? this[key] : null; 



    }
}
