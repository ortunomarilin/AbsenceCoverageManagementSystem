using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedLeaveTypes : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType { LeaveTypeId = "1", Name = "PTO" },
                new LeaveType { LeaveTypeId = "2", Name = "Medical" },
                new LeaveType { LeaveTypeId = "3", Name = "Personal" }
                );
        }
    }
}
