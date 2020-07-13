using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class AbsenceTypeListViewModel
    {
        //For Current Route values 
        public GridDictionary Grid { get; set; }

        //For List of Users 
        public IEnumerable<AbsenceType> AbsenceTypes { get; set; }

    }
}
