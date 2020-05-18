using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.DTO;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.QueryOptions
{
    public class CoverageQueryOptions : QueryOptions<AbsenceRequest>
    {

        public void Search(CoverageGridBuilder gridBuilder)
        {
            if (gridBuilder.CurrentGrid.Search != null)
            {
                string searchTerm = gridBuilder.CurrentGrid.Search.ToLower();
                Where = ar => ar.User.FirstName.ToLower().Contains(searchTerm) || ar.User.LastName.ToLower().Contains(searchTerm);
            }
        }

        public void FromDateRange(CoverageGridBuilder gridBuilder)
        {

            if (gridBuilder.CurrentGrid.FromDate != null && gridBuilder.CurrentGrid.ToDate != null)
            {
                DateTime fromDate = gridBuilder.ConvertToDateTime(gridBuilder.CurrentGrid.FromDate);
                DateTime toDate = gridBuilder.ConvertToDateTime(gridBuilder.CurrentGrid.ToDate);

                Where = ar => ar.StartDate >= fromDate && ar.StartDate <= toDate;
            }

        }


        public void Filter(CoverageGridBuilder gridBuilder)
        {

            if (gridBuilder.CurrentGrid.Duration != "all")
            {
                Where = ar => ar.DurationTypeId == gridBuilder.CurrentGrid.Duration;
            }


            if (gridBuilder.CurrentGrid.SubJobStatus != "all" && gridBuilder.CurrentGrid.SubJobStatus != "none" )
            {
                Where = ar => ar.SubJob.CoverageStatusTypeId == gridBuilder.CurrentGrid.SubJobStatus;
            }

            if (gridBuilder.CurrentGrid.SubJobStatus == "none")
            {
                Where = ar => ar.SubJob.CoverageStatusTypeId == null;
            }

        }


        public void Sort(CoverageGridBuilder gridBuilder)
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
                case nameof(AbsenceRequest.DurationType):
                    OrderBy = ar => ar.DurationType.Name;
                    break;
                case nameof(FilterGridDTO.SubJobStatus):
                    OrderBy = ar => ar.SubJob.CoverageStatusType;
                    break;
                default:
                    OrderBy = ar => ar.StartDate;
                    break;
            }

        }

    }
}
