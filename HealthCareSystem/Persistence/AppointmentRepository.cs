using HealthCareSystem.Core;
using HealthCareSystem.Models;
using HealthCareSystem.DbContextFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.ModelsResources;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Persistence

{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext context;

        public AppointmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateAppointment(Appointment appointment)
        {
          this.context.Appointments.AddAsync(appointment);
        }

        public Task<Appointment> GetAppointmentAsync(int id)
        {
            return context.Appointments.Include(a=>a.Doctor).Include(a=>a.Time).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(QueryResource query)
        {
            var appointments = await context.Appointments.Include( a=> a.Time).ToListAsync();

            if (query.DoctorId.HasValue) { appointments = appointments.FindAll(a => a.DoctorId == query.DoctorId); }

            if (query.Date.HasValue) { appointments = appointments.FindAll(a => a.Date == query.Date); }

            if (query.PatientId != 0)
            {
                { appointments = appointments.FindAll(a => a.PatientId == query.PatientId); }
            }
            else
            {  // Vraca samo appointment-e koji su dostupni za zakzaivanje
                appointments = appointments.FindAll(a => a.PatientId == 0);
            }
            appointments = appointments.OrderBy(a => a.Time.AppointmentTime).ToList();

            return appointments;
        }

        public async Task<IEnumerable<Appointment>> GetScheduledAppointmentsAsync(QueryResource query)
        {
            var appointments = await context.Appointments.Include(a => a.Time).Include(a => a.Patient).ToListAsync();

            if (query.DoctorId.HasValue) { appointments = appointments.FindAll(a => a.DoctorId == query.DoctorId); }

            if (query.Date.HasValue) { appointments = appointments.FindAll(a => a.PatientId != 0); }

            appointments = appointments.OrderBy(a => a.Time.AppointmentTime).ToList();

            return appointments;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            context.Entry(appointment).State = EntityState.Modified;
        }

        public void DeleteAppointment(Appointment appointment) {
         
            context.Appointments.Remove(appointment);
        }
    }
}
