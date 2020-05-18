using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class NewDatabaseERD : Migration
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
                name: "CoverageStatusTypeId",
                table: "SubJobs",
                nullable: true);

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
                name: "CoverageStatusTypes",
                columns: table => new
                {
                    CoverageStatusTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageStatusTypes", x => x.CoverageStatusTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "CoverageJobs",
                columns: table => new
                {
                    CoverageJobId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PeriodId = table.Column<string>(nullable: false),
                    TeacherInstructions = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CoverageStatusTypeId = table.Column<string>(nullable: true),
                    AbsenceRequestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageJobs", x => x.CoverageJobId);
                    table.ForeignKey(
                        name: "FK_CoverageJobs_AbsenceRequests_AbsenceRequestId",
                        column: x => x.AbsenceRequestId,
                        principalTable: "AbsenceRequests",
                        principalColumn: "AbsenceRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverageJobs_CoverageStatusTypes_CoverageStatusTypeId",
                        column: x => x.CoverageStatusTypeId,
                        principalTable: "CoverageStatusTypes",
                        principalColumn: "CoverageStatusTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverageJobs_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverageJobs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationUser",
                columns: table => new
                {
                    NotificationId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUser", x => new { x.NotificationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_NotificationUser_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "CoverageStatusTypes",
                columns: new[] { "CoverageStatusTypeId", "Name" },
                values: new object[,]
                {
                    { "1", "Filled" },
                    { "2", "Unfilled" },
                    { "3", "Canceled" },
                    { "4", "Unreleased" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId",
                unique: true,
                filter: "[AbsenceRequestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_CoverageStatusTypeId",
                table: "SubJobs",
                column: "CoverageStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_DurationTypeId",
                table: "SubJobs",
                column: "DurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_AbsenceStatusTypeId",
                table: "AbsenceRequests",
                column: "AbsenceStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageJobs_AbsenceRequestId",
                table: "CoverageJobs",
                column: "AbsenceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageJobs_CoverageStatusTypeId",
                table: "CoverageJobs",
                column: "CoverageStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageJobs_PeriodId",
                table: "CoverageJobs",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageJobs_UserId",
                table: "CoverageJobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUser_UserId",
                table: "NotificationUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceRequests_AbsenceStatusTypes_AbsenceStatusTypeId",
                table: "AbsenceRequests",
                column: "AbsenceStatusTypeId",
                principalTable: "AbsenceStatusTypes",
                principalColumn: "AbsenceStatusTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_CoverageStatusTypes_CoverageStatusTypeId",
                table: "SubJobs",
                column: "CoverageStatusTypeId",
                principalTable: "CoverageStatusTypes",
                principalColumn: "CoverageStatusTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_DurationTypes_DurationTypeId",
                table: "SubJobs",
                column: "DurationTypeId",
                principalTable: "DurationTypes",
                principalColumn: "DurationTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceRequests_AbsenceStatusTypes_AbsenceStatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_CoverageStatusTypes_CoverageStatusTypeId",
                table: "SubJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_DurationTypes_DurationTypeId",
                table: "SubJobs");

            migrationBuilder.DropTable(
                name: "AbsenceStatusTypes");

            migrationBuilder.DropTable(
                name: "CoverageJobs");

            migrationBuilder.DropTable(
                name: "NotificationUser");

            migrationBuilder.DropTable(
                name: "CoverageStatusTypes");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_CoverageStatusTypeId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_DurationTypeId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceRequests_AbsenceStatusTypeId",
                table: "AbsenceRequests");

            migrationBuilder.DropColumn(
                name: "CoverageStatusTypeId",
                table: "SubJobs");

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
