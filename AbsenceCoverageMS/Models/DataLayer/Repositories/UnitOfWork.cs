﻿using AbsenceCoverageMS.Models.DomainModels;
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
        public Repository<AbsenceRequestPeriod> AbsenceRequestsPeriods
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


        private Repository<Course> courseRepo;
        public Repository<Course> Courses
        {
            get
            {
                if (courseRepo == null)
                {
                    courseRepo = new Repository<Course>(context);
                }
                return courseRepo;
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


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
