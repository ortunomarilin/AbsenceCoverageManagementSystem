using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels
{
    public class AbsenceDetailsViewModel
    {
        public AbsenceRequest AbsenceRequest { get; set; }

        public GridDictionary Grid { get; set; }



        public string GetPeriodsNeedCoverage()
        {
            string periods = "";
            foreach (var arp in AbsenceRequest.AbsenceRequestPeriods)
            {
                periods += arp.PeriodId + " ";
            }
            return periods;
        }
    }
}
