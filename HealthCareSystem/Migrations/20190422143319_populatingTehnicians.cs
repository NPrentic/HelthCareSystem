using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingTehnicians : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender) VALUES('Milan Petrović',2,'milan123','male')");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender) VALUES('Goran Kaludjerović',2,'goran123','male')");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender) VALUES('Ivana Pavićević',2,'ivana123','female')");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender) VALUES('Jelena Marković',2,'Jelena123','female')");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender) VALUES('Vuk Milić',2,'vuk123','male')");
            migrationBuilder.Sql("INSERT INTO Tehnicians(Name, FacilityId,Password,Gender) VALUES('Bojana Mitović',2,'Bojana123','female')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Tehnicians");
        }
    }
}
