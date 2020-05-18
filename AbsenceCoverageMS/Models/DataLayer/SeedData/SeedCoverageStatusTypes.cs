using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedCoverageStatusTypes : IEntityTypeConfiguration<CoverageStatusType>
    {
        public void Configure(EntityTypeBuilder<CoverageStatusType> builder)
        {
            builder.HasData(
                new CoverageStatusType { CoverageStatusTypeId = "1", Name = "Filled" },
                new CoverageStatusType { CoverageStatusTypeId = "2", Name = "Unfilled" },
                new CoverageStatusType { CoverageStatusTypeId = "3", Name = "Canceled" },
                new CoverageStatusType { CoverageStatusTypeId = "4", Name = "Unreleased" }
            );
        }
    }
}
