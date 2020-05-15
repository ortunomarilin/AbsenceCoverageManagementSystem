using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class ConfigureWithAPIRelationshipAbsenceRequestAndSubJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId",
                unique: true,
                filter: "[AbsenceRequestId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_AbsenceRequestId",
                table: "SubJobs",
                column: "AbsenceRequestId");
        }
    }
}
