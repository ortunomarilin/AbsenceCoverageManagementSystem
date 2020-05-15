using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.QueryOptions
{
    public class SubJobQueryOptions : QueryOptions<SubJob>
    {


        public void Filter(SubJobGridBuilder gridBuilder)
        {
            //Filter by Campus 
            if (gridBuilder.CurrentGrid.Campus != "all")
            {
                Where = job => job.AbsenceRequest.User.Campus.CampusId == gridBuilder.CurrentGrid.Campus;
            }

            if(gridBuilder.CurrentGrid.Duration != "all")
            {
                Where = job => job.AbsenceRequest.DurationType.DurationTypeId == gridBuilder.CurrentGrid.Duration;
            }
        }

        public void Sort(SubJobGridBuilder gridBuilder)
        {
            //SortBy
            switch (gridBuilder.CurrentGrid.SortBy)
            {
                case nameof(AbsenceRequest.StartDate):
                    OrderBy = job => job.AbsenceRequest.StartDate;
                    break;
                case nameof(AbsenceRequest.DurationType):
                    OrderBy = job => job.AbsenceRequest.DurationType.Name;
                    break;
                default:
                    OrderBy = job => job.AbsenceRequest.StartDate;
                    break;
            }

        }




    }
}
