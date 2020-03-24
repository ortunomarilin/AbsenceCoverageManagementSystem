using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class AddDomainModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CampusId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoveragePeriodId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CampusId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    LeaveTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    PeriodId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.PeriodId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProcessingRequestId = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: false),
                    DateProcessed = table.Column<DateTime>(nullable: false),
                    ProcessorComments = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
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
                name: "SubJobs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SubJobId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    AbsenceRequestId = table.Column<string>(nullable: false),
                    AbsenceRequest = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubJobs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProfileId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    TeachingSubjects = table.Column<string>(nullable: true),
                    CampusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceBalances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AbsenceBalanceId = table.Column<string>(nullable: true),
                    LeaveTypeId = table.Column<string>(nullable: false),
                    Granted = table.Column<int>(nullable: false),
                    Used = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AbsenceRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AbsenceRequestId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    TypeLeaveTypeId = table.Column<string>(nullable: false),
                    RequestorComments = table.Column<string>(nullable: true),
                    NeedCoverage = table.Column<bool>(nullable: false),
                    SubJobId = table.Column<string>(nullable: true),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_LeaveTypes_TypeLeaveTypeId",
                        column: x => x.TypeLeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PeriodId = table.Column<string>(nullable: false),
                    Room = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoveragePeriods",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CoveragePeriodId = table.Column<string>(nullable: true),
                    PeriodId = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Count = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoveragePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoveragePeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyCoverages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmergencyCoverageId = table.Column<string>(nullable: true),
                    SubJobId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CampusId",
                table: "AspNetUsers",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CoveragePeriodId",
                table: "AspNetUsers",
                column: "CoveragePeriodId",
                unique: true,
                filter: "[CoveragePeriodId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceBalances_LeaveTypeId",
                table: "AbsenceBalances",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceBalances_UserId",
                table: "AbsenceBalances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_TypeLeaveTypeId",
                table: "AbsenceRequests",
                column: "TypeLeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_UserId",
                table: "AbsenceRequests",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CampusId",
                table: "Profiles",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_UserId",
                table: "SubJobs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CoveragePeriods_CoveragePeriodId",
                table: "AspNetUsers",
                column: "CoveragePeriodId",
                principalTable: "CoveragePeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CoveragePeriods_CoveragePeriodId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AbsenceBalances");

            migrationBuilder.DropTable(
                name: "AbsenceRequests");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CoveragePeriods");

            migrationBuilder.DropTable(
                name: "EmergencyCoverages");

            migrationBuilder.DropTable(
                name: "ProcessingRequests");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "SubJobs");

            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CoveragePeriodId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CoveragePeriodId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");
        }
    }
}
