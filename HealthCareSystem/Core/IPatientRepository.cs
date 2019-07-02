using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
   public interface IPatientRepository
    {
        Task<Patient> GetPatientAsync(int id);
        
        Task<Patient> GetPatientsAsync(string cardNumber);

        void UpdatePatient(Patient patient);

        void DeletePatient(Patient patient);

    }
}
