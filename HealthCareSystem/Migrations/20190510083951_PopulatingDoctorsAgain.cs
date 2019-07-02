using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class PopulatingDoctorsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Vanja Marković',3,1,13,'vanja123',1,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Milos Marković',1,2,11,'milos123',2,2)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Milena Ivanović',2,2,23,'milena123',3,2)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Milan Perović',1,1,33,'milan123',4,2)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Ivana Petrović',2,1,43,'ivana123',5,2)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Goran Milić',4,2,32,'goran123',6,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Petar Mitrović',4,4,2,'petar123',7,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Slavka Vujošević',5,1,41,'slavka123',8,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Bojan Popović',6,1,11,'bojan123',9,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Biljana Nedović',12,1,7,'biljana123',10,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Marko Jovanović',13,1,8,'marko123',11,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Jovana Knežević',19,1,23,'jovana123',12,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Boris Knežević',9,1,22,'boris123',13,3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId,RoleId) VALUES('Milica Božović',8,1,6,'milica123',14,3)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Doctors");
        }
    }
}
