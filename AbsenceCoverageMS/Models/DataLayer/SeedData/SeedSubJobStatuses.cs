using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedSubJobStatuses : IEntityTypeConfiguration<SubJobStatus>
    {
        public void Configure(EntityTypeBuilder<SubJobStatus> builder)
        {
            builder.HasData(
                new SubJobStatus { SubJobStatusId = "1", Name = "Filled" },
                new SubJobStatus { SubJobStatusId = "2", Name = "Unfilled" },
                new SubJobStatus { SubJobStatusId = "3", Name = "Canceled" }
            );
        }
    }
}
