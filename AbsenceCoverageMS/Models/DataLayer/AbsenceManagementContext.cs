using AbsenceCoverageMS.Models.DataLayer.SeedData;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer
{
    public class AbsenceManagementContext : IdentityDbContext<User>
    {

        public AbsenceManagementContext(DbContextOptions<AbsenceManagementContext> options)
            : base(options)
        { }

        public DbSet<SubJob> SubJobs { get; set; }
        public DbSet<ProcessingRequest> ProcessingRequests { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<EmergencyCoverage> EmergencyCoverages { get; set; }
        public DbSet<CoveragePeriod> CoveragePeriods { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<AbsenceRequest> AbsenceRequests { get; set; }
        public DbSet<AbsenceBalance> AbsenceBalances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new SeedLeaveTypes());
            modelBuilder.ApplyConfiguration(new SeedPeriods());
            modelBuilder.ApplyConfiguration(new SeedCampuses());
        }


    }
}
