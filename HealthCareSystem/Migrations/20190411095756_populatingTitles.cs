using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingTitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Izabrani ljekar za djecu - Pedijatar', 'false')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Ljekar opšte prakse', 'false')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista kardiologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista pumologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista dermatologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista urologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista otorinolaringlologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista defektologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista oftamologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista radiologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista epidemologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista farmakologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista infektologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista neurologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista psihijatrije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista abdomalne hirurgije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista vaskularne hirurgije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista grudne hirurgije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista djecije hirurgije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista ortopedske hirurgije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista neurohirurgije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista anesteziologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista fizikalne medicine', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista medicine rada', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista patologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista imunologije', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista sportske medicine', 'true')");
            migrationBuilder.Sql("INSERT INTO Titles(Name, IsSpecialist) VALUES('Specijalista internisticke onkologije', 'true')");
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Titles");
        }
    }
}
