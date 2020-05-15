using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AbsenceManagementContext context { get; set; }


        //Constructor 
        public UnitOfWork (AbsenceManagementContext ctx)
        {
            context = ctx;
        }



        //Repositories
        //Private Variables and Public Properties 

        private Repository<AbsenceRequest> absentRequestRepo;
        public Repository<AbsenceRequest> AbsenceRequests
        {
            get
            {
                if(absentRequestRepo == null)
                {
                    absentRequestRepo = new Repository<AbsenceRequest>(context);
                }
                return absentRequestRepo;
            }
        }


        private Repository<AbsenceRequestPeriod> absenceRequestPeriodRepo;
        public Repository<AbsenceRequestPeriod> AbsenceRequestPeriods
        {
            get
            {
                if (absenceRequestPeriodRepo == null)
                {
                    absenceRequestPeriodRepo = new Repository<AbsenceRequestPeriod>(context);
                }
                return absenceRequestPeriodRepo;
            }
        }


        private Repository<AbsenceType> absenceTypeRepo;
        public Repository<AbsenceType> AbsenceTypes
        {
            get
            {
                if (absenceTypeRepo == null)
                {
                    absenceTypeRepo = new Repository<AbsenceType>(context);
                }
                return absenceTypeRepo;
            }
        }


        private Repository<DurationType> durationTypeRepo;
        public Repository<DurationType> DurationTypes
        {
            get
            {
                if (durationTypeRepo == null)
                {
                    durationTypeRepo = new Repository<DurationType>(context);
                }
                return durationTypeRepo;
            }
        }


        private Repository<StatusType> statusTypeRepo;
        public Repository<StatusType> StatusTypes
        {
            get
            {
                if (statusTypeRepo == null)
                {
                    statusTypeRepo = new Repository<StatusType>(context);
                }
                return statusTypeRepo;
            }
        }


        private Repository<Campus> campusRepo;
        public Repository<Campus> Campuses
        {
            get
            {
                if (campusRepo == null)
                {
                    campusRepo = new Repository<Campus>(context);
                }
                return campusRepo;
            }
        }



        private Repository<CoveragePeriod> coveragePeriodRepo;
        public Repository<CoveragePeriod> CoveragePeriods
        {
            get
            {
                if (coveragePeriodRepo == null)
                {
                    coveragePeriodRepo = new Repository<CoveragePeriod>(context);
                }
                return coveragePeriodRepo;
            }
        }


        private Repository<Period> periodRepo;
        public Repository<Period> Periods
        {
            get
            {
                if (periodRepo == null)
                {
                    periodRepo = new Repository<Period>(context);
                }
                return periodRepo;
            }
        }


        private Repository<SubJob> subJobRepo;
        public Repository<SubJob> SubJobs
        {
            get
            {
                if (subJobRepo == null)
                {
                    subJobRepo = new Repository<SubJob>(context);
                }
                return subJobRepo;
            }
        }


        private Repository<CoverageAssignment> CoverageAssignmentRepo;
        public Repository<CoverageAssignment> CoverageAssignments
        {
            get
            {
                if (CoverageAssignmentRepo == null)
                {
                    CoverageAssignmentRepo = new Repository<CoverageAssignment>(context);
                }
                return CoverageAssignmentRepo;
            }
        }


        public void AddNewCoverageAssignments(SubJob subJob)
        {
            foreach(AbsenceRequestPeriod arp in subJob.AbsenceRequest.AbsenceRequestPeriods)
            {
                CoverageAssignment coverageAssgnment = new CoverageAssignment
                {
                    SubJob = subJob,
                    Period = arp.Period,
                    StatusType = StatusTypes.List().Where(st => st.Name == "Unfilled").FirstOrDefault(),
                };
                CoverageAssignments.Insert(coverageAssgnment);

            }
        }

        public void DeleteCoverageAssignments(SubJob subJob)
        {
            foreach(CoverageAssignment coverageAssignment in subJob.CoverageAssignments)
            {
                CoverageAssignments.Delete(coverageAssignment);
            }
        }



        public void AddNewAbsenceRequestPeriods(AbsenceRequest absenceRequest, List<SelectablePeriodViewModel> selectablePeriods)
        {
            //Add the AbsenceRequestPeriods 
            foreach (SelectablePeriodViewModel p in selectablePeriods)
            {
                if (p.Checked == true)
                {
                    AbsenceRequestPeriod arp = new AbsenceRequestPeriod
                    {
                        AbsenceRequest = absenceRequest,
                        PeriodId = p.PeriodId
                    };
                    AbsenceRequestPeriods.Insert(arp);
                }
            }
        }

        public void DeleteAbsenceRequestPeriods(AbsenceRequest absenceRequest)
        {
            //Get the current AbsenceRequestPeriods for this absenceRequest 
            var currentPeriods = AbsenceRequestPeriods.List(new QueryOptions<AbsenceRequestPeriod>
            {
                Where = arp => arp.AbsenceRequestId == absenceRequest.AbsenceRequestId
            });

            //Delete all of the records aquired above. 
            foreach (AbsenceRequestPeriod arp in currentPeriods)
            {
                AbsenceRequestPeriods.Delete(arp);
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
