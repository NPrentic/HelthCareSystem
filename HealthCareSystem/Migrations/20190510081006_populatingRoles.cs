using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roles(Name) VALUES('Administrator')");
            migrationBuilder.Sql("INSERT INTO Roles(Name) VALUES('nonSpecialist')");
            migrationBuilder.Sql("INSERT INTO Roles(Name) VALUES('Specialist')");
            migrationBuilder.Sql("INSERT INTO Roles(Name) VALUES('Tehnician')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Roles");
        }
    }
}
