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

            if (gridBuilder.CurrentGrid.Campus != "all")
            {
                Where = job => job.AbsenceRequest.User.Campus.CampusId == gridBuilder.CurrentGrid.Campus;
            }

            if (gridBuilder.CurrentGrid.Duration != "all")
            {
                Where = job => job.DurationTypeId == gridBuilder.CurrentGrid.Duration;
            }

        }



        public void Sort(SubJobGridBuilder gridBuilder)
        {
            //SortBy
            switch (gridBuilder.CurrentGrid.SortBy)
            {
                case nameof(SubJob.StartDate):
                    OrderBy = job => job.StartDate;
                    break;
                case nameof(SubJob.DurationType):
                    OrderBy = job => job.DurationType.Name;
                    break;
                case nameof(SubJob.AbsenceRequest.User.Campus):
                    OrderBy = job => job.AbsenceRequest.User.Campus.Name;
                    break;
                default:
                    OrderBy = job => job.StartDate;
                    break;
            }

        }


    }
}
