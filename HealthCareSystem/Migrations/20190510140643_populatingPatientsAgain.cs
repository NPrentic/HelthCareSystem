using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareSystem.Migrations
{
    public partial class populatingPatientsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Marko Marković',18,'male','20071112','Brako','A pozitivna','1112007118','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Nina Dabanović',18,'female','20120618','Goran','B negativna','1806012938','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Mladen Kovačević',18,'male','20040102','Milan','nulta','0201004772','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Lazar Vukićević',19,'male','20171107','Nemanja','nulta','07110172283','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Ana Božović',19,'female','19901112','Radisav','A negativna','12119901192','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Jelena Jokić',17,'female','19970708','Ivan','AB pozitivna','0807997663','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Ivan Mihailović',19,'male','19690227','Danilo','B pozitivna','2702969969','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Dijana Vuković',17,'female','19800520','Vasilije','AB negativna','2005908635','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Vesna Ristić',19,'female','20080115','Vuk','A negativna','1501008938','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Dragana Janković',17,'female','19940606','Obrad','AB pozitivna','0606996723','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Boris Lučić',19,'male','20090111','Milovan','B pozitivna','1110009721','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Filip Dulović',17,'male','19850505','Luka','AB negativna','0505985273','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Jovan Bulatović',19,'male','20110411','Petar','A negativna','1104011827','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Marko Tomašević',17,'male','19770707','Goran','AB pozitivna','0707977263','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Bojana Mitrović',19,'female','20130404','Momir','B pozitivna','0404013662','false')");
            migrationBuilder.Sql("INSERT INTO Patients(Name,DoctorId,Gender,DateOfBirth,FatherName,BloodType,cardNumber,HasAppointment) VALUES('Ivana Radonjić',17,'female','19880525','Igor','AB negativna','2505988237','false')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Patients");
        }
    }
}
