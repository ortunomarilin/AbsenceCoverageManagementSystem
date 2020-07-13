using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceStatusTypes",
                columns: table => new
                {
                    AbsenceStatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceStatusTypes", x => x.AbsenceStatusId);
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    CampusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    OpenTime = table.Column<DateTime>(nullable: false),
                    CloseTime = table.Column<DateTime>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.CampusId);
                });

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
                name: "Periods",
                columns: table => new
                {
                    PeriodId = table.Column<string>(nullable: false),
                    PeriodNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.PeriodId);
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PositionTitle = table.Column<string>(nullable: false),
                    CampusId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceRequests",
                columns: table => new
                {
                    AbsenceRequestId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    AbsenceTypeId = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    DurationTypeId = table.Column<string>(nullable: false),
                    NeedCoverage = table.Column<bool>(nullable: false),
                    AbsenceStatusId = table.Column<string>(nullable: true),
                    StatusRemarks = table.Column<string>(nullable: true),
                    DateProcessed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceRequests", x => x.AbsenceRequestId);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_AbsenceStatusTypes_AbsenceStatusId",
                        column: x => x.AbsenceStatusId,
                        principalTable: "AbsenceStatusTypes",
                        principalColumn: "AbsenceStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_AbsenceTypes_AbsenceTypeId",
                        column: x => x.AbsenceTypeId,
                        principalTable: "AbsenceTypes",
                        principalColumn: "AbsenceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_DurationTypes_DurationTypeId",
                        column: x => x.DurationTypeId,
                        principalTable: "DurationTypes",
                        principalColumn: "DurationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "AbsenceRequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsenceRequestPeriod_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubJobs",
                columns: table => new
                {
                    SubJobId = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    DurationTypeId = table.Column<string>(nullable: false),
                    TeacherInstructions = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    SubJobStatusId = table.Column<string>(nullable: true),
                    AbsenceRequestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubJobs", x => x.SubJobId);
                    table.ForeignKey(
                        name: "FK_SubJobs_AbsenceRequests_AbsenceRequestId",
                        column: x => x.AbsenceRequestId,
                        principalTable: "AbsenceRequests",
                        principalColumn: "AbsenceRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubJobs_DurationTypes_DurationTypeId",
                        column: x => x.DurationTypeId,
                        principalTable: "DurationTypes",
                        principalColumn: "DurationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubJobs_SubJobStatuses_SubJobStatusId",
                        column: x => x.SubJobStatusId,
                        principalTable: "SubJobStatuses",
                        principalColumn: "SubJobStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubJobs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AbsenceStatusTypes",
                columns: new[] { "AbsenceStatusId", "Name" },
                values: new object[,]
                {
                    { "1", "Submitted" },
                    { "2", "Approved" },
                    { "3", "Denied" },
                    { "4", "Canceled" }
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

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "CampusId", "City", "CloseTime", "Name", "OpenTime", "Phone", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { "1", "Houston", new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Home Office", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-111-1111", 41, "444 Street", "7704" },
                    { "2", "Houston", new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "South", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1231", 41, "111 Street", "7701" },
                    { "3", "Houston", new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "West", new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1232", 41, "222 Street", "7702" },
                    { "4", "Houston", new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "East", new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1233", 41, "333 Street", "7703" },
                    { "5", "Houston", new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "North", new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "713-123-1234", 41, "444 Street", "7704" }
                });

            migrationBuilder.InsertData(
                table: "DurationTypes",
                columns: new[] { "DurationTypeId", "Name" },
                values: new object[,]
                {
                    { "2", "Half Day" },
                    { "1", "Full Day" }
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "PeriodId", "Name", "PeriodNumber" },
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
                name: "IX_AbsenceRequestPeriod_PeriodId",
                table: "AbsenceRequestPeriod",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_AbsenceStatusId",
                table: "AbsenceRequests",
                column: "AbsenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_AbsenceTypeId",
                table: "AbsenceRequests",
                column: "AbsenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_DurationTypeId",
                table: "AbsenceRequests",
                column: "DurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceRequests_UserId",
                table: "AbsenceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CampusId",
                table: "AspNetUsers",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_SubJobs_UserId",
                table: "SubJobs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsenceRequestPeriod");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SubJobs");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AbsenceRequests");

            migrationBuilder.DropTable(
                name: "SubJobStatuses");

            migrationBuilder.DropTable(
                name: "AbsenceStatusTypes");

            migrationBuilder.DropTable(
                name: "AbsenceTypes");

            migrationBuilder.DropTable(
                name: "DurationTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Campuses");
        }
    }
}
