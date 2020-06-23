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


        private Repository<AbsenceStatusType> AbsenceStatusTypeRepo;
        public Repository<AbsenceStatusType> AbsenceStatusTypes
        {
            get
            {
                if (AbsenceStatusTypeRepo == null)
                {
                    AbsenceStatusTypeRepo = new Repository<AbsenceStatusType>(context);
                }
                return AbsenceStatusTypeRepo;
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



        private Repository<SubJobStatus> subJobStatusRepo;
        public Repository<SubJobStatus> SubJobStatuses
        {
            get
            {
                if (subJobStatusRepo == null)
                {
                    subJobStatusRepo = new Repository<SubJobStatus>(context);
                }
                return subJobStatusRepo;
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
