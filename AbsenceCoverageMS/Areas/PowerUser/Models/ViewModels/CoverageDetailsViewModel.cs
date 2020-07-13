using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels
{
    public class CoverageDetailsViewModel
    {
        public AbsenceRequest AbsenceRequest { get; set; }

        public GridDictionary Grid { get; set; }



        
        //To add coverage jobs

        [Required]
        public string PeriodId { get; set; }

        [Required]
        public string UserId { get; set; }


        [Required]
        public DateTime? Date { get; set; }

        public List<string> Dates { get; set; }


      



        public string GetPeriodsNeedCoverage()
        {
            string periods = "";
            foreach (var arp in AbsenceRequest.AbsenceRequestPeriods.OrderBy(ca => ca.PeriodId).ToList())
            {
                periods += arp.PeriodId + " ";
            }
            return periods;
        }

    }
}
