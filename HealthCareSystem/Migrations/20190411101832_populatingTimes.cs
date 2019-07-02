using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('07:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('07:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('07:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('07:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('08:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('08:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('08:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('08:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('09:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('09:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('09:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('09:45')");

            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('10:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('10:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('11:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('11:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('11:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('11:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('12:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('12:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('12:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('12:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('13:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('13:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('13:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('13:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('14:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('14:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('14:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('14:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('15:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('15:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('15:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('15:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('16:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('16:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('16:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('16:45')");
           
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('17:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('17:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('18:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('18:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('18:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('18:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('18:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('19:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('19:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('19:45')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('20:00')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('20:15')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('20:30')");
            migrationBuilder.Sql("INSERT INTO Times(ApointmentTime) VALUES('20:45')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TIMES");
        }
    }
}
