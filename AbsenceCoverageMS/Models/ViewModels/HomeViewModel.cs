using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<AbsenceRequest> AbsenceRequests { get; set; }

        public int WaitingApproval { get; set; }
        public int Approved { get; set; }
        public int Denied { get; set; }

        public Dictionary<string, int> TotalAbsences { get; set; } 
        

    }


}
