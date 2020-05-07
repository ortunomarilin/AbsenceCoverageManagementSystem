using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedDurationTypes : IEntityTypeConfiguration<DurationType>
    {
        public void Configure(EntityTypeBuilder<DurationType> builder)
        {
            builder.HasData(
                new DurationType { DurationTypeId = "1", Name = "Full Day" },
                new DurationType { DurationTypeId = "2", Name = "Half Day" }
            );
        }
    }
}
