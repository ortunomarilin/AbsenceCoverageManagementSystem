using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class RemovedCoverageJobEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_StatusTypes_StatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_Courses_CourseId",
                table: "SubJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_Periods_PeriodId",
                table: "SubJobs");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CoveragePeriods");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_CourseId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_PeriodId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_StatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.AddColumn<string>(
                name: "DurationTypeId",
                table: "SubJobs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "SubJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "SubJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "SubJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "SubJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SubJobStatusId",
                table: "SubJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherInstructions",
                table: "SubJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbsenceStatusTypeId",
                table: "AbsenceRequests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbsenceStatusTypes",
                columns: table => new
                {
                    AbsenceStatusTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceStatusTypes", x => x.AbsenceStatusTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SubJobStatuses",
                columns: table => new
                {
                    SubJobStatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubJobStatuses", x => x.SubJobStatusId);
                });

            migrationBuilder.InsertData(
                table: "AbsenceStatusTypes",
                columns: new[] { "AbsenceStatusTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "Submitted" },
                    { "2", "Approved" },
                    { "3", "Denied" },
                    { "4", "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "SubJobStatuses",
                columns: new[] { "SubJobStatusId", "Name" },
                values: new object[,]
                {
                    { "1", "Filled" },
                    { "2", "Unfilled" },
                    { "3", "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId",
                unique: true,
                filter: "[AbsenceRequestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_DurationTypeId",
                table: "SubJobs",
                column: "DurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_SubJobStatusId",
                table: "SubJobs",
                column: "SubJobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_AbsenceStatusTypeId",
                table: "AbsenceRequests",
                column: "AbsenceStatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceRequests_AbsenceStatusTypes_AbsenceStatusTypeId",
                table: "AbsenceRequests",
                column: "AbsenceStatusTypeId",
                principalTable: "AbsenceStatusTypes",
                principalColumn: "AbsenceStatusTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_DurationTypes_DurationTypeId",
                table: "SubJobs",
                column: "DurationTypeId",
                principalTable: "DurationTypes",
                principalColumn: "DurationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_SubJobStatuses_SubJobStatusId",
                table: "SubJobs",
                column: "SubJobStatusId",
                principalTable: "SubJobStatuses",
                principalColumn: "SubJobStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_AbsenceStatusTypes_AbsenceStatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_DurationTypes_DurationTypeId",
                table: "SubJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_SubJobStatuses_SubJobStatusId",
                table: "SubJobs");

            migrationBuilder.DropTable(
                name: "AbsenceStatusTypes");

            migrationBuilder.DropTable(
                name: "SubJobStatuses");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_DurationTypeId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_SubJobStatusId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_AbsenceStatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "DurationTypeId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "SubJobStatusId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "TeacherInstructions",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "AbsenceStatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "SubJobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SubJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "SubJobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusTypeId",
                table: "AbsenceRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoveragePeriods",
                columns: table => new
                {
                    CoveragePeriodId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoveragePeriods", x => x.CoveragePeriodId);
                    table.ForeignKey(
                        name: "FK_CoveragePeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoveragePeriods_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    StatusTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.StatusTypeId);
                });

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
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_CourseId",
                table: "SubJobs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_PeriodId",
                table: "SubJobs",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_StatusTypeId",
                table: "AbsenceRequests",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PeriodId",
                table: "Courses",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoveragePeriods_PeriodId",
                table: "CoveragePeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CoveragePeriods_UserId",
                table: "CoveragePeriods",
                column: "UserId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_Periods_PeriodId",
                table: "SubJobs",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "PeriodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
