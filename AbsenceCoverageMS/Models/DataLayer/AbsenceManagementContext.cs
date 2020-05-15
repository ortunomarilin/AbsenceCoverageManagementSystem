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
        public DbSet<DurationType> DurationTypes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<CoveragePeriod> CoveragePeriods { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<SubJob> SubJobs { get; set; }
        public DbSet<CoverageAssignment> CoverageAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Composite primary key for AbsenceRequestPeriod
            modelBuilder.Entity<AbsenceRequestPeriod>()
                .HasKey(k => new { k.AbsenceRequestId, k.PeriodId });

            //One to Many relationship between AbsenceRequest and AbsenceRequestPeriod
            modelBuilder.Entity<AbsenceRequestPeriod>()
                .HasOne(arp => arp.AbsenceRequest)
                .WithMany(ar => ar.AbsenceRequestPeriods)
                .HasForeignKey(arp => arp.AbsenceRequestId);

            //One to Many relationship between Period and AbsenceRequestPeriod
            modelBuilder.Entity<AbsenceRequestPeriod>()
                .HasOne(arp => arp.Period)
                .WithMany(p => p.AbsenceRequestPeriods)
                .HasForeignKey(arp => arp.PeriodId);


            //One to One relationship between AbsenceRequest and SubJob
            modelBuilder.Entity<AbsenceRequest>()
                .HasOne(ar => ar.SubJob)
                .WithOne(sj => sj.AbsenceRequest)
                .HasForeignKey<SubJob>(sj => sj.AbsenceRequestId);




            //Primary key for AbsenceRequest
            modelBuilder.Entity<AbsenceRequest>()
                .HasKey(k => new { k.AbsenceRequestId});


            //Primary key for SubJob
            modelBuilder.Entity<CoverageAssignment>()
                .HasKey(k => new { k.CoverageAssignmentId });

            //Primary key for CoveragePeriod
            modelBuilder.Entity<CoveragePeriod>()
                .HasKey(k => new { k.CoveragePeriodId });



            modelBuilder.ApplyConfiguration(new SeedAbsenceTypes());
            modelBuilder.ApplyConfiguration(new SeedDurationTypes());
            modelBuilder.ApplyConfiguration(new SeedStatusTypes());
            modelBuilder.ApplyConfiguration(new SeedPeriods());
            modelBuilder.ApplyConfiguration(new SeedCampuses());
        }


    }
}
