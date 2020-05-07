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
                new Period { PeriodId = "1", Name = "Period 1", PeriodNumber = 1},
                new Period { PeriodId = "2", Name = "Period 2", PeriodNumber = 2},
                new Period { PeriodId = "3", Name = "Period 3", PeriodNumber = 3},
                new Period { PeriodId = "4", Name = "Period 4", PeriodNumber = 4},
                new Period { PeriodId = "5", Name = "Period 5", PeriodNumber = 5},
                new Period { PeriodId = "6", Name = "Period 6", PeriodNumber = 6},
                new Period { PeriodId = "7", Name = "Period 7", PeriodNumber = 7},
                new Period { PeriodId = "8", Name = "Period 8", PeriodNumber = 8},
                new Period { PeriodId = "9", Name = "Period 9", PeriodNumber = 9}
            );
        }

    }
}
