using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models
{
    public class AbsenceQueryOptions : QueryOptions<AbsenceRequest>
    {

        public void Search(AbsenceGridBuilder gridBuilder)
        {
            if (gridBuilder.CurrentGrid.Search != null)
            {
                string searchTerm = gridBuilder.CurrentGrid.Search.ToLower();
                Where = ar => ar.User.FirstName.ToLower().Contains(searchTerm) || ar.User.LastName.ToLower().Contains(searchTerm);
            }
        }

        public void FromDateRange(AbsenceGridBuilder gridBuilder)
        {

            if (gridBuilder.CurrentGrid.FromDate != null && gridBuilder.CurrentGrid.ToDate != null)
            {
                DateTime fromDate = gridBuilder.ConvertToDateTime(gridBuilder.CurrentGrid.FromDate);
                DateTime toDate = gridBuilder.ConvertToDateTime(gridBuilder.CurrentGrid.ToDate);

                Where = ar => ar.StartDate >= fromDate && ar.StartDate <= toDate;
            }

        }


        public void Filter(AbsenceGridBuilder gridBuilder)
        {

            if (gridBuilder.CurrentGrid.AbsenceType != "all")
            {
                Where = ar => ar.AbsenceTypeId == gridBuilder.CurrentGrid.AbsenceType;
            }
            if (gridBuilder.CurrentGrid.Duration != "all")
            {
                Where = ar => ar.DurationTypeId == gridBuilder.CurrentGrid.Duration;
            }
            if (gridBuilder.CurrentGrid.NeedCoverage != "all")
            {
                bool boolValue;
                if(Boolean.TryParse(gridBuilder.CurrentGrid.NeedCoverage, out boolValue))
                {
                    Where = ar => ar.NeedCoverage == boolValue;
                }

                
            }
            if (gridBuilder.CurrentGrid.Status != "all")
            {
                Where = ar => ar.StatusTypeId == gridBuilder.CurrentGrid.Status;
            }

        }

        public void Sort(AbsenceGridBuilder gridBuilder)
        {
            //SortBy
            switch (gridBuilder.CurrentGrid.SortBy)
            {
                case nameof(AbsenceRequest.StartDate):
                    OrderBy = ar => ar.StartDate;
                    break;
                case nameof(AbsenceRequest.User.LastName):
                    OrderBy = ar => ar.User.LastName;
                    break;
                case nameof(AbsenceRequest.AbsenceType):
                    OrderBy = ar => ar.AbsenceType.Name;
                    break;
                case nameof(AbsenceRequest.DurationType):
                    OrderBy = ar => ar.DurationType.Name;
                    break;
                case nameof(AbsenceRequest.StatusType):
                    OrderBy = ar => ar.StatusType.Name;
                    break;
                default:
                    OrderBy = ar => ar.StartDate;
                    break;
            }

        }
    }
}
