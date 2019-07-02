using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class PopulatingTehniciansAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId,RoleId) VALUES('Milan Petrović',2,'milan123','male',15,4)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId,RoleId) VALUES('Goran Kaludjerović',2,'goran123','male',16,4)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId,RoleId) VALUES('Ivana Pavićević',2,'ivana123','female',17,4)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId,RoleId) VALUES('Jelena Marković',2,'Jelena123','female',18,4)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId,RoleId) VALUES('Vuk Milić',2,'vuk123','male',19,4)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId,RoleId) VALUES('Bojana Mitović',2,'Bojana123','female',20,4)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Tehnicians");
        }
    }
}
