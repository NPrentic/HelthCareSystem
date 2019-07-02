using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class addingRoleToDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Doctors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoleId",
                table: "Doctors",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Roles_RoleId",
                table: "Doctors",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Roles_RoleId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RoleId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Doctors");
        }
    }
}
