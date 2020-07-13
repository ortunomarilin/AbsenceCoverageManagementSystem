using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.QueryOptions
{
    public class AbsenceTypeQueryOptions : QueryOptions<AbsenceType>
    {
        public void Search(GridBuilder gridBuilder)
        {
            if (gridBuilder.CurrentGrid.Search != null)
            {
                string searchTerm = gridBuilder.CurrentGrid.Search.ToLower();
                Where = at => at.Name.ToLower().Contains(searchTerm);
            }
        }
    }
}
