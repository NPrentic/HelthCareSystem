using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Admins(UserId, Password, FacilityId,RoleId) VALUES(26,'P@ssw0rd',1,1)");
            migrationBuilder.Sql("INSERT INTO Admins(UserId, Password, FacilityId,RoleId) VALUES(27,'P@ssw0rd',2,1)");
            migrationBuilder.Sql("INSERT INTO Admins(UserId, Password, FacilityId,RoleId) VALUES(28,'P@ssw0rd',3,1)");
            migrationBuilder.Sql("INSERT INTO Admins(UserId, Password, FacilityId,RoleId) VALUES(29,'P@ssw0rd',4,1)");
            migrationBuilder.Sql("INSERT INTO Admins(UserId, Password, FacilityId,RoleId) VALUES(30,'P@ssw0rd',5,1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Admins");
        }
    }
}
