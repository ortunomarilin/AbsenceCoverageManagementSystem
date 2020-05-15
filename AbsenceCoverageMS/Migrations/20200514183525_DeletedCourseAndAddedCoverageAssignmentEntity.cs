using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class DeletedCourseAndAddedCoverageAssignmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_Periods_PeriodId",
                table: "SubJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubJobs_AspNetUsers_UserId",
                table: "SubJobs");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_PeriodId",
                table: "SubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobs_UserId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "SubJobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SubJobs");

            migrationBuilder.CreateTable(
                name: "CoverageAssignments",
                columns: table => new
                {
                    CoverageAssignmentId = table.Column<string>(nullable: false),
                    TeacherInstructions = table.Column<string>(nullable: true),
                    SubJobId = table.Column<string>(nullable: true),
                    PeriodId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StatusTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageAssignments", x => x.CoverageAssignmentId);
                    table.ForeignKey(
                        name: "FK_CoverageAssignments_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverageAssignments_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "StatusTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverageAssignments_SubJobs_SubJobId",
                        column: x => x.SubJobId,
                        principalTable: "SubJobs",
                        principalColumn: "SubJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverageAssignments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverageAssignments_PeriodId",
                table: "CoverageAssignments",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageAssignments_StatusTypeId",
                table: "CoverageAssignments",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageAssignments_SubJobId",
                table: "CoverageAssignments",
                column: "SubJobId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageAssignments_UserId",
                table: "CoverageAssignments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverageAssignments");

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "SubJobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SubJobs",
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

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_PeriodId",
                table: "SubJobs",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_UserId",
                table: "SubJobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PeriodId",
                table: "Courses",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_Periods_PeriodId",
                table: "SubJobs",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "PeriodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobs_AspNetUsers_UserId",
                table: "SubJobs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
