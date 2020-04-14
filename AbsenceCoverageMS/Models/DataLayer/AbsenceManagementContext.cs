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

        public DbSet<AbsenceRequest> AbsenceRequests { get; set; }
        public DbSet<AbsenceType> AbsenceTypes { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoveragePeriod> CoveragePeriods { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<SubJob> SubJobs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Composite primary key for AbsenceRequestPeriod
            modelBuilder.Entity<AbsenceRequestPeriod>()
                .HasKey(k => new { k.AbsenceRequestId, k.PeriodId });

            //One to Many relationship between AbsenceRequest and AbsenceRequestPeriod
            modelBuilder.Entity<AbsenceRequestPeriod>()
                .HasOne(arp => arp.AbsenceRequest)
                .WithMany(ar => ar.PeriodsNeedCoverage)
                .HasForeignKey(arp => arp.AbsenceRequestId);


            //One ot Many relationship between Period and AbsenceRequestPeriod
            modelBuilder.Entity<AbsenceRequestPeriod>()
                .HasOne(arp => arp.Period)
                .WithMany(p => p.PeriodsNeedCoverage)
                .HasForeignKey(arp => arp.PeriodId);


            modelBuilder.ApplyConfiguration(new SeedAbsenceTypes());
            modelBuilder.ApplyConfiguration(new SeedPeriods());
            modelBuilder.ApplyConfiguration(new SeedCampuses());
        }


    }
}
