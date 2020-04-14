using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class UpdatedDatabaseToAlignWithNewERD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_LeaveTypes_TypeLeaveTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AbsenceBalances");

            migrationBuilder.DropTable(
                name: "EmergencyCoverages");

            migrationBuilder.DropTable(
                name: "ProcessingRequests");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_TypeLeaveTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeachingSubjects",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "RequestorComments",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "SubJobId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "TypeLeaveTypeId",
                table: "AbsenceRequests");

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceRequestId",
                table: "SubJobs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SubJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "SubJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Campuses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CampusId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoveragePeriod",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionTitle",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsenceTypeId",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateProcessed",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AbsenceRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusRemarks",
                table: "AbsenceRequests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbsenceRequestPeriod",
                columns: table => new
                {
                    AbsenceRequestId = table.Column<string>(nullable: false),
                    PeriodId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceRequestPeriod", x => new { x.AbsenceRequestId, x.PeriodId });
                    table.ForeignKey(
                        name: "FK_AbsenceRequestPeriod_AbsenceRequests_AbsenceRequestId",
                        column: x => x.AbsenceRequestId,
                        principalTable: "AbsenceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceRequestPeriod_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceTypes",
                columns: table => new
                {
                    AbsenceTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceTypes", x => x.AbsenceTypeId);
                });

            migrationBuilder.InsertData(
                table: "AbsenceTypes",
                columns: new[] { "AbsenceTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "PTO" },
                    { "2", "Business/Professional" },
                    { "3", "Jury Duty" }
                });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "1",
                column: "Phone",
                value: "713-123-1231");

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "2",
                column: "Phone",
                value: "713-123-1232");

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "3",
                column: "Phone",
                value: "713-123-1233");

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: "4",
                column: "Phone",
                value: "713-123-1234");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_PeriodId",
                table: "SubJobs",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_AbsenceTypeId",
                table: "AbsenceRequests",
                column: "AbsenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequestPeriod_PeriodId",
                table: "AbsenceRequestPeriod",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceRequests_AbsenceTypes_AbsenceTypeId",
                table: "AbsenceRequests",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "AbsenceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_AbsenceRequests_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId",
                principalTable: "AbsenceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_Periods_PeriodId",
                table: "SubJobs",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "PeriodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_AbsenceTypes_AbsenceTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_AbsenceRequests_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_Periods_PeriodId",
                table: "SubJobs");

            migrationBuilder.DropTable(
                name: "AbsenceRequestPeriod");

            migrationBuilder.DropTable(
                name: "AbsenceTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_PeriodId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_AbsenceTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "CoveragePeriod",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PositionTitle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AbsenceTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "DateProcessed",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "StatusRemarks",
                table: "AbsenceRequests");

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceRequestId",
                table: "SubJobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SubJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Periods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CampusId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeachingSubjects",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "AbsenceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RequestorComments",
                table: "AbsenceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubJobId",
                table: "AbsenceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "AbsenceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TypeLeaveTypeId",
                table: "AbsenceRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmergencyCoverages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmergencyCoverageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubJobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyCoverages_SubJobs_SubJobId",
                        column: x => x.SubJobId,
                        principalTable: "SubJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyCoverages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    LeaveTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessingRequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceBalances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbsenceBalanceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    Granted = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Used = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbsenceBalances_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceBalances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "LeaveTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "PTO" },
                    { "2", "Medical" },
                    { "3", "Personal" }
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

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_TypeLeaveTypeId",
                table: "AbsenceRequests",
                column: "TypeLeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceBalances_LeaveTypeId",
                table: "AbsenceBalances",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceBalances_UserId",
                table: "AbsenceBalances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyCoverages_SubJobId",
                table: "EmergencyCoverages",
                column: "SubJobId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyCoverages_UserId",
                table: "EmergencyCoverages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingRequests_UserId",
                table: "ProcessingRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceRequests_LeaveTypes_TypeLeaveTypeId",
                table: "AbsenceRequests",
                column: "TypeLeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "LeaveTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
