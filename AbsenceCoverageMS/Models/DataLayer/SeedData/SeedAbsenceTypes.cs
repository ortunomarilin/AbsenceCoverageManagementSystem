using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedAbsenceTypes : IEntityTypeConfiguration<AbsenceType>
    {
        public void Configure(EntityTypeBuilder<AbsenceType> builder)
        {
            builder.HasData(
                new AbsenceType { AbsenceTypeId = "1", Name = "PTO" },
                new AbsenceType { AbsenceTypeId = "2", Name = "Business/Professional" },
                new AbsenceType { AbsenceTypeId = "3", Name = "Jury Duty" }
                );
        }
    }
}
