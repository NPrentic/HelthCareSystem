using HealthCareSystem.Core;
using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.DbContextFolder;
using HealthCareSystem.ModelsResources;

namespace HealthCareSystem.Persistence
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext context;

        public DoctorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateDoctor(Doctor doctor)
        {
            this.context.Add(doctor);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            this.context.Remove(doctor);
        }


        public async Task<Doctor> getDoctorAsync(int doctorId)
        {
            var doctor = await this.context.Doctors
                .Include(d => d.Facility)
                .Include(d => d.Title)
                .SingleOrDefaultAsync(d => d.Id ==doctorId);

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            var doctors = await this.context.Doctors
                .Include(d => d.Title)
                .Include(d => d.Facility)
                .Include(d => d.Role)
                .ToListAsync();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(QueryResource query)
        {
            var doctors = await this.context.Doctors
                .Include(d =>d.Title)
                .Include(d => d.Facility)
                .ToListAsync();

            if (query.FacilityId != null) { doctors = doctors.FindAll(d => d.FacilityId.ToString() == query.FacilityId); }

            if (query.UserId != 0) { doctors = doctors.FindAll(d => d.UserId == query.UserId); }

            if (query.Title != null) { doctors = doctors.FindAll(d => d.Title.Name == query.Title); }

            doctors = doctors.OrderBy(d => d.Name).ToList(); 

            return doctors;
        }
    }
}
