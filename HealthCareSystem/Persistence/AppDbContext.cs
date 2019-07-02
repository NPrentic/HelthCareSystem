using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HealthCareSystem.DbContextFolder
{
    public class AppDbContext : DbContext
    {

     public DbSet<Title> Titles { get; set; }
     public DbSet<Time> Times { get; set; }
     public DbSet<Facility> Facilities { get; set; }
     public DbSet<Doctor> Doctors { get; set; }
     public DbSet<Patient> Patients { get; set; }
     public DbSet<Appointment> Appointments { get; set; }
     public DbSet<DoctorShift> DoctorShifts { get; set; }
     public DbSet<Tehnician> Tehnicians { get; set; }
     public DbSet<TehnicianShift> TehniciansShifts { get; set; }
     public DbSet<Role> Roles { get; set; }
     public DbSet<Admin> Admins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  { }

    }
}
