using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels
{
    public class CoverageListViewModel
    {


        //For Current Grid 
        public GridDictionary Grid { get; set; }



        //For List of Absence Requests 
        public IEnumerable<AbsenceRequest> AbsenceRequests { get; set; }



        //For DropDown Filter Select Lists 
        public IEnumerable<DurationType> DurationTypes { get; set; }
        public IEnumerable<CoverageStatusType> CoverageStatusTypes { get; set; }



        //For Total number of pages
        public double TotalPages { get; set; }



        public string GetPeriodsNeedCoverage(AbsenceRequest ar)
        {
            string periods = "";
            foreach(AbsenceRequestPeriod period in ar.AbsenceRequestPeriods.OrderBy(arp => arp.PeriodId).ToList())
            {
                periods += period.PeriodId + " ";
            }
            return periods;
        }


   }
}
