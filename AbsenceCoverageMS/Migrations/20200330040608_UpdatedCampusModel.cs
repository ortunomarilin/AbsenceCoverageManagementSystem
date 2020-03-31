using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenceCoverageMS.Migrations
{
    public partial class UpdatedCampusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campuses",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Campuses");

            migrationBuilder.AlterColumn<string>(
                name: "CampusId",
                table: "Campuses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campuses",
                table: "Campuses",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campuses",
                table: "Campuses");

            migrationBuilder.AlterColumn<string>(
                name: "CampusId",
                table: "Campuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Campuses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campuses",
                table: "Campuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campuses_CampusId",
                table: "AspNetUsers",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
