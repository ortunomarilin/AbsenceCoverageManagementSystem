using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models
{
    public class AbsenceRequestQueryOptions : QueryOptions<AbsenceRequest>
    {

        public void FromDateRange(AbsenceGridBuilder gridBuilder)
        {

            if (gridBuilder.GetCurrentRoute.FromDate != null && gridBuilder.GetCurrentRoute.ToDate != null)
            {
                DateTime fromDate = gridBuilder.ConvertToDateTime(gridBuilder.GetCurrentRoute.FromDate);
                DateTime toDate = gridBuilder.ConvertToDateTime(gridBuilder.GetCurrentRoute.ToDate);

                Where = ar => ar.StartDate >= fromDate && ar.StartDate <= toDate;
            }

        }


        public void Filter(AbsenceGridBuilder gridBuilder)
        {

            if (gridBuilder.GetCurrentRoute.AbsenceType != "all")
            {
                Where = ar => ar.AbsenceTypeId == gridBuilder.GetCurrentRoute.AbsenceType;
            }
            if (gridBuilder.GetCurrentRoute.Duration != "all")
            {
                Where = ar => ar.DurationTypeId == gridBuilder.GetCurrentRoute.Duration;
            }
            if (gridBuilder.GetCurrentRoute.NeedCoverage != "all")
            {
                bool boolValue;
                if(Boolean.TryParse(gridBuilder.GetCurrentRoute.NeedCoverage, out boolValue))
                {
                    Where = ar => ar.NeedCoverage == boolValue;
                }

                
            }
            if (gridBuilder.GetCurrentRoute.Status != "all")
            {
                Where = ar => ar.StatusTypeId == gridBuilder.GetCurrentRoute.Status;
            }

        }

        public void sort(AbsenceGridBuilder gridBuilder)
        {
            //SortBy
            switch (gridBuilder.GetCurrentRoute.SortBy)
            {
                case "date":
                    OrderBy = ar => ar.StartDate;
                    break;
                case "absencetype":
                    OrderBy = ar => ar.AbsenceType.Name;
                    break;
                case "duration":
                    OrderBy = ar => ar.DurationType.Name;
                    break;
                case "status":
                    OrderBy = ar => ar.StatusType.Name;
                    break;
                default:
                    OrderBy = ar => ar.StartDate;
                    break;
            }

        }
    }
}
