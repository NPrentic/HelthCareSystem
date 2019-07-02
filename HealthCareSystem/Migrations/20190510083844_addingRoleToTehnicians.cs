using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class addingRoleToTehnicians : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Tehnicians",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tehnicians_RoleId",
                table: "Tehnicians",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tehnicians_Roles_RoleId",
                table: "Tehnicians",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tehnicians_Roles_RoleId",
                table: "Tehnicians");

            migrationBuilder.DropIndex(
                name: "IX_Tehnicians_RoleId",
                table: "Tehnicians");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Tehnicians");
        }
    }
}
