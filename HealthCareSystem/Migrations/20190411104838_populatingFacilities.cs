using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingFacilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Facilities(Name,City,Address, ContactPhone, ContactEmail) VALUES('Klinicki centar Crne Gore', 'Podgorica', 'Džona Džeksona bb','020412267','info@kccg.me')");
            migrationBuilder.Sql("INSERT INTO Facilities(Name,City,Address, ContactPhone, ContactEmail) VALUES('Dom zdravlja Stari Aerodrom', 'Podgorica', 'V Proleterske b.b',' 020657108','dzstariaerodrom@kccg.me')");
            migrationBuilder.Sql("INSERT INTO Facilities(Name,City,Address, ContactPhone, ContactEmail) VALUES('Dom zdravlja Bar', 'Bar', 'Jovana Tomaševića 42',' 020655503','dzbar@kccg.me')");
            migrationBuilder.Sql("INSERT INTO Facilities(Name,City,Address, ContactPhone, ContactEmail) VALUES('JZU Opšta bolnica Nikšić', 'Nikšić', 'Radoja Dakića bb','020343277','jzuniksic@kccg.me')");
            migrationBuilder.Sql("INSERT INTO Facilities(Name,City,Address, ContactPhone, ContactEmail) VALUES('Dom zdravlja Blok 5', 'Podgorica', 'Trg Nikole Kovačevića 6',' 020997836','dzblokv@kccg.me')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Facilities");

        }
    }
}