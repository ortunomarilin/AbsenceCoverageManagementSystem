using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class AddedPeriodNumberToPeriodEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodNumber",
                table: "Periods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "1",
                column: "PeriodNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "2",
                column: "PeriodNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "3",
                column: "PeriodNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "4",
                column: "PeriodNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "5",
                column: "PeriodNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "6",
                column: "PeriodNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "7",
                column: "PeriodNumber",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "8",
                column: "PeriodNumber",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "9",
                column: "PeriodNumber",
                value: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodNumber",
                table: "Periods");
        }
    }
}
