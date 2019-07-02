using HealthCareSystem.Core;
using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.DbContextFolder;

namespace HealthCareSystem.Persistence
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext context;

        public PatientRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Patient> GetPatientAsync(int patientId)
        {
          var patient = await this.context.Patients.FindAsync(patientId);
            return patient;
        }

        public async Task<Patient> GetPatientsAsync(string cardNumber)

        {
            var patient = await this.context.Patients.SingleOrDefaultAsync(p => p.CardNumber == cardNumber);
            return patient;
        }

        public void UpdatePatient(Patient patient)
        {
            context.Entry(patient).State = EntityState.Modified;
        }

        public void DeletePatient(Patient patient)
        {
            context.Patients.Remove(patient);
        }
    }
}
