using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class SeedCampusHoursOfOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CloseTime",
                table: "Campuses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTime",
                table: "Campuses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "0",
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "1",
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "2",
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "3",
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "4",
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Campuses");
        }
    }
}
