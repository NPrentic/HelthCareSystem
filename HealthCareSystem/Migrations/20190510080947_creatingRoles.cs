using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class creatingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tehnicians",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Doctors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_FacilityId",
                table: "Doctors",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeId",
                table: "Appointments",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Times_TimeId",
                table: "Appointments",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Facilities_FacilityId",
                table: "Doctors",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Times_TimeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Facilities_FacilityId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_FacilityId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tehnicians");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctors");
        }
    }
}
