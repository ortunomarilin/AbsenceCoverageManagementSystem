using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbsenceCoverageMS.Models.DataLayer.SeedData
{
    public class SeedCampuses : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.HasData(
                new Campus { CampusId = "1",  Name = "South", StreetAddress = "111 Street", City = "Houston", State = States.TX, ZipCode = "7701"},
                new Campus { CampusId = "2", Name = "West", StreetAddress = "222 Street", City = "Houston", State = States.TX, ZipCode = "7702" },
                new Campus { CampusId = "3", Name = "East", StreetAddress = "333 Street", City = "Houston", State = States.TX, ZipCode = "7703" },
                new Campus { CampusId = "4", Name = "North", StreetAddress = "444 Street", City = "Houston", State = States.TX, ZipCode = "7704" }
                );
        }
    }
}
