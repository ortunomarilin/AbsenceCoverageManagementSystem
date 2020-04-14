using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    internal class SeedPeriods : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder.HasData(
                new Period { PeriodId = "1", Number = 1},
                new Period { PeriodId = "2", Number = 2},
                new Period { PeriodId = "3", Number = 3},
                new Period { PeriodId = "4", Number = 4},
                new Period { PeriodId = "5", Number = 5},
                new Period { PeriodId = "6", Number = 6},
                new Period { PeriodId = "7", Number = 7},
                new Period { PeriodId = "8", Number = 8},
                new Period { PeriodId = "9", Number = 9}
            );
        }

    }
}
