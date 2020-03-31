using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class SeedCampusData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "CampusId", "City", "Name", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { "1", "Houston", "South", 41, "111 Street", "7701" },
                    { "2", "Houston", "West", 41, "222 Street", "7702" },
                    { "3", "Houston", "East", 41, "333 Street", "7703" },
                    { "4", "Houston", "North", 41, "444 Street", "7704" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "4");
        }
    }
}
