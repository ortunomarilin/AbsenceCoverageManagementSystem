using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedStatusTypes : IEntityTypeConfiguration<StatusType>
    {
        public void Configure(EntityTypeBuilder<StatusType> builder)
        {
            builder.HasData(
                new StatusType { StatusTypeId = "1", Name = "Submitted" },
                new StatusType { StatusTypeId = "2", Name = "Approved" },
                new StatusType { StatusTypeId = "3", Name = "Denied" },
                new StatusType { StatusTypeId = "4", Name = "Canceled" }
            );
        }
    }
}
