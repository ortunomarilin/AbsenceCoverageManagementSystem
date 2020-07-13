using AbsenceCoverageMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.Repositories
{
    public interface IUnitOfWork
    {
        Repository<AbsenceRequest> AbsenceRequests { get; }
        Repository<AbsenceRequestPeriod> AbsenceRequestPeriods { get; }
        Repository<AbsenceType> AbsenceTypes { get; }
        Repository<Campus> Campuses { get; }
        Repository<Period> Periods { get; }
        Repository<SubJob> SubJobs { get; }
        Repository<AbsenceStatus> AbsenceStatusTypes { get; }
        Repository<SubJobStatus> SubJobStatuses { get; }



        void Save();
    }
}
