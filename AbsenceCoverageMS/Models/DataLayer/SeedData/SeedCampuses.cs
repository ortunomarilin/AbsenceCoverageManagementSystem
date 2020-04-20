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
                new Campus {
                    CampusId = "0",
                    Name = "Home Office", 
                    Phone = "713-111-1111",
                    OpenTime = new DateTime(2020, 8, 01, 7, 0, 0),
                    CloseTime = new DateTime(2020, 8, 01, 17, 0, 0),
                    StreetAddress = "444 Street", 
                    City = "Houston", 
                    State = States.TX, 
                    ZipCode = "7704" 
                },

                new Campus {
                    CampusId = "1",
                    Name = "South", 
                    Phone = "713-123-1231",
                    OpenTime = new DateTime(2020, 8, 01, 7, 0, 0),
                    CloseTime = new DateTime(2020, 8, 01, 16, 0, 0),
                    StreetAddress = "111 Street", 
                    City = "Houston", 
                    State = States.TX, 
                    ZipCode = "7701"
                },

                new Campus {
                    CampusId = "2",
                    Name = "West", 
                    Phone = "713-123-1232",
                    OpenTime = new DateTime(2020, 8, 01, 8, 0, 0),
                    CloseTime = new DateTime(2020, 8, 01, 17, 0, 0),
                    StreetAddress = "222 Street", 
                    City = "Houston", 
                    State = States.TX, 
                    ZipCode = "7702" 
                },

                new Campus {
                    CampusId = "3",
                    Name = "East", 
                    Phone = "713-123-1233",
                    OpenTime = new DateTime(2020, 8, 01, 8, 0, 0),
                    CloseTime = new DateTime(2020, 8, 01, 17, 0, 0),
                    StreetAddress = "333 Street", 
                    City = "Houston", 
                    State = States.TX, 
                    ZipCode = "7703" 
                },

                new Campus {
                    CampusId = "4",
                    Name = "North", 
                    Phone = "713-123-1234",
                    OpenTime = new DateTime(2020, 8, 01, 7, 0, 0),
                    CloseTime = new DateTime(2020, 8, 01, 16, 0, 0),
                    StreetAddress = "444 Street", 
                    City = "Houston", 
                    State = States.TX, 
                    ZipCode = "7704" 
                });
        }
    }
}
