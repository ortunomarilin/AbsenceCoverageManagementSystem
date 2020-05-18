using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.ViewModels
{
    public class AbsenceListViewModel
    {

        //For Current Route 
        public GridDictionary Grid { get; set; }

        //For List of Absence Requests 
        public IEnumerable<AbsenceRequest> AbsenceRequests { get; set; }


        //For DropDown Filter Select Lists 
        public IEnumerable<AbsenceType> AbsenceTypes { get; set; }    
        public IEnumerable<DurationType> DurationTypes { get; set; }  
        public IEnumerable<AbsenceStatusType> StatusTypes { get; set; }


        //For Total number of pages
        public double TotalPages { get; set; }

    }
}
