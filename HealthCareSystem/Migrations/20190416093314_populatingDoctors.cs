using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Vanja Marković',3,1,13,'vanja123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Milos Marković',1,2,11,'milos123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Milena Ivanović',2,2,23,'milena123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Milan Perović',1,1,33,'milan123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Ivana Petrović',2,1,43,'ivana123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Goran Milić',4,2,32,'goran123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Petar Mitrović',4,4,2,'petar123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Slavka Vujošević',5,1,41,'slavka123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Bojan Popović',6,1,11,'bojan123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Biljana Nedović',12,1,7,'biljana123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Marko Jovanović',13,1,8,'marko123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Jovana Knežević',19,1,23,'jovana123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Boris Knežević',9,1,22,'boris123')");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password) VALUES('Milica Božović',8,1,6,'milica123')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Doctors");
        }
    }
}
