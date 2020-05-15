using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class CorrectedSubJobModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_Courses_CourseId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_CourseId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SubJobs");

            migrationBuilder.AddColumn<string>(
                name: "StatusTypeId",
                table: "SubJobs",
                nullable: true);

            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "StatusTypeId", "Name" },
                values: new object[] { "5", "Filled" });

            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "StatusTypeId", "Name" },
                values: new object[] { "6", "Unfilled" });

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_StatusTypeId",
                table: "SubJobs",
                column: "StatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_StatusTypes_StatusTypeId",
                table: "SubJobs",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "StatusTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_StatusTypes_StatusTypeId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_StatusTypeId",
                table: "SubJobs");

            migrationBuilder.DeleteData(
                table: "StatusTypes",
                keyColumn: "StatusTypeId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "StatusTypes",
                keyColumn: "StatusTypeId",
                keyValue: "6");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "SubJobs");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_CourseId",
                table: "SubJobs",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_Courses_CourseId",
                table: "SubJobs",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
