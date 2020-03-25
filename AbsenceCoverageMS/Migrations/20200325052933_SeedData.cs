using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "LeaveTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "PTO" },
                    { "2", "Medical" },
                    { "3", "Personal" }
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "PeriodId", "Name", "Number" },
                values: new object[,]
                {
                    { "1", "Period 1", 1 },
                    { "2", "Period 2", 2 },
                    { "3", "Period 3", 3 },
                    { "4", "Period 4", 4 },
                    { "5", "Period 5", 5 },
                    { "6", "Period 6", 6 },
                    { "7", "Period 7", 7 },
                    { "8", "Period 8", 8 },
                    { "9", "Period 9", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "9");
        }
    }
}
