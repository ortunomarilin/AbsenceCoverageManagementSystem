using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class UpdatedCampusSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "0");

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "1",
                columns: new[] { "CloseTime", "Name", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Home Office", "713-111-1111", "444 Street", "7704" });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "2",
                columns: new[] { "CloseTime", "Name", "OpenTime", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "South", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1231", "111 Street", "7701" });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "3",
                columns: new[] { "Name", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { "West", "713-123-1232", "222 Street", "7702" });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "4",
                columns: new[] { "CloseTime", "Name", "OpenTime", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "East", new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1233", "333 Street", "7703" });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "CampusId", "City", "CloseTime", "Name", "OpenTime", "Phone", "State", "StreetAddress", "ZipCode" },
                values: new object[] { "5", "Houston", new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "North", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1234", 41, "444 Street", "7704" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "5");

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "1",
                columns: new[] { "CloseTime", "Name", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "South", "713-123-1231", "111 Street", "7701" });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "2",
                columns: new[] { "CloseTime", "Name", "OpenTime", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "West", new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1232", "222 Street", "7702" });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "3",
                columns: new[] { "Name", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { "East", "713-123-1233", "333 Street", "7703" });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "4",
                columns: new[] { "CloseTime", "Name", "OpenTime", "Phone", "StreetAddress", "ZipCode" },
                values: new object[] { new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "North", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1234", "444 Street", "7704" });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "CampusId", "City", "CloseTime", "Name", "OpenTime", "Phone", "State", "StreetAddress", "ZipCode" },
                values: new object[] { "0", "Houston", new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Home Office", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-111-1111", 41, "444 Street", "7704" });
        }
    }
}
