using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Marko Marković',6,'male','20071112','Brako','A pozitivna','1112007118','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Nina Dabanović',6,'female','20120618','Goran','B negativna','1806012938','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Mladen Kovačević',6,'male','20040102','Milan','nulta','0201004772','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Lazar Vukićević',7,'male','20171107','Nemanja','nulta','07110172283','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Ana Božović',7,'female','19901112','Radisav','A negativna','12119901192','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Jelena Jokić',5,'female','19970708','Ivan','AB pozitivna','0807997663','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Ivan Mihailović',7,'male','19690227','Danilo','B pozitivna','2702969969','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Dijana Vuković',5,'female','19800520','Vasilije','AB negativna','2005908635','false')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Patients");
        }
    }
}
