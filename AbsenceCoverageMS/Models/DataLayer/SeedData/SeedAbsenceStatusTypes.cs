using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedAbsenceStatusTypes : IEntityTypeConfiguration<AbsenceStatusType>
    {
        public void Configure(EntityTypeBuilder<AbsenceStatusType> builder)
        {
            builder.HasData(
                new AbsenceStatusType { AbsenceStatusTypeId = "1", Name = "Submitted" },
                new AbsenceStatusType { AbsenceStatusTypeId = "2", Name = "Approved" },
                new AbsenceStatusType { AbsenceStatusTypeId = "3", Name = "Denied" },
                new AbsenceStatusType { AbsenceStatusTypeId = "4", Name = "Canceled" }
            );
        }
    }
}
