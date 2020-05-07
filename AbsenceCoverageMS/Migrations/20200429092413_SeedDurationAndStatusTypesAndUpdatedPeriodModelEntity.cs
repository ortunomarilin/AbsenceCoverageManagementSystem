using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class SeedDurationAndStatusTypesAndUpdatedPeriodModelEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AbsenceRequests");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "SubJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Periods",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DurationTypeId",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusTypeId",
                table: "AbsenceRequests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DurationTypes",
                columns: table => new
                {
                    DurationTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationTypes", x => x.DurationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    StatusTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.StatusTypeId);
                });

            migrationBuilder.InsertData(
                table: "DurationTypes",
                columns: new[] { "DurationTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "Full Day" },
                    { "2", "Half Day" }
                });

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "1",
                column: "Name",
                value: "Period 1");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "2",
                column: "Name",
                value: "Period 2");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "3",
                column: "Name",
                value: "Period 3");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "4",
                column: "Name",
                value: "Period 4");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "5",
                column: "Name",
                value: "Period 5");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "6",
                column: "Name",
                value: "Period 6");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "7",
                column: "Name",
                value: "Period 7");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "8",
                column: "Name",
                value: "Period 8");

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "9",
                column: "Name",
                value: "Period 9");

            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "StatusTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "Submitted" },
                    { "2", "Approved" },
                    { "3", "Denied" },
                    { "4", "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_CourseId",
                table: "SubJobs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_DurationTypeId",
                table: "AbsenceRequests",
                column: "DurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_StatusTypeId",
                table: "AbsenceRequests",
                column: "StatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceRequests_DurationTypes_DurationTypeId",
                table: "AbsenceRequests",
                column: "DurationTypeId",
                principalTable: "DurationTypes",
                principalColumn: "DurationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceRequests_StatusTypes_StatusTypeId",
                table: "AbsenceRequests",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "StatusTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_Courses_CourseId",
                table: "SubJobs",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_DurationTypes_DurationTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_StatusTypes_StatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_Courses_CourseId",
                table: "SubJobs");

            migrationBuilder.DropTable(
                name: "DurationTypes");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_CourseId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_DurationTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_StatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "DurationTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Periods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AbsenceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AbsenceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "1",
                column: "Number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "2",
                column: "Number",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "3",
                column: "Number",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "4",
                column: "Number",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "5",
                column: "Number",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "6",
                column: "Number",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "7",
                column: "Number",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "8",
                column: "Number",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "PeriodId",
                keyValue: "9",
                column: "Number",
                value: 9);
        }
    }
}
