using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class EmptyingDoctorsAndTehnicians : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Doctors");

            migrationBuilder.Sql("DELETE FROM Tehnicians");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Vanja Marković',31,1,13,'vanja123',1)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Milos Marković',29,2,11,'milos123',2)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Milena Ivanović',30,2,23,'milena123',3)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Milan Perović',29,1,33,'milan123',4)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Ivana Petrović',30,1,43,'ivana123',5)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Goran Milić',32,2,32,'goran123',6)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Petar Mitrović',32,4,2,'petar123',7)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Slavka Vujošević',33,1,41,'slavka123',8)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Bojan Popović',34,1,11,'bojan123',9)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Biljana Nedović',40,1,7,'biljana123',10)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Marko Jovanović',41,1,8,'marko123',11)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Jovana Knežević',47,1,23,'jovana123',12)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Boris Knežević',37,1,22,'boris123',13)");
            migrationBuilder.Sql("INSERT INTO Doctors(Name,TitleId, FacilityId, Ambulance, Password,UserId) VALUES('Milica Božović',36,1,6,'milica123',14)");

            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId) VALUES('Milan Petrović',2,'milan123','male',15)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId) VALUES('Goran Kaludjerović',2,'goran123','male',16)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId) VALUES('Ivana Pavićević',2,'ivana123','female',17)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId) VALUES('Jelena Marković',2,'Jelena123','female',18)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId) VALUES('Vuk Milić',2,'vuk123','male',19)");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender,UserId) VALUES('Bojana Mitović',2,'Bojana123','female',20)");

        }
    }
}
