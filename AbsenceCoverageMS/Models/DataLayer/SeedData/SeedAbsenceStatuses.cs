using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedAbsenceStatuses : IEntityTypeConfiguration<AbsenceStatus>
    {
        public void Configure(EntityTypeBuilder<AbsenceStatus> builder)
        {
            builder.HasData(
                new AbsenceStatus { AbsenceStatusId = "1", Name = "Submitted" },
                new AbsenceStatus { AbsenceStatusId = "2", Name = "Approved" },
                new AbsenceStatus { AbsenceStatusId = "3", Name = "Denied" },
                new AbsenceStatus { AbsenceStatusId = "4", Name = "Canceled" }
            );
        }
    }
}
