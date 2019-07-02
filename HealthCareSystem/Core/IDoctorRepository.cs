using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface IDoctorRepository
    {
        Task<Doctor> getDoctorAsync(int doctorId);

        Task<IEnumerable<Doctor>> GetDoctorsAsync();

        Task<IEnumerable<Doctor>> GetDoctorsAsync(QueryResource query);

        void CreateDoctor(Doctor doctor);

        void DeleteDoctor(Doctor doctor);

    }
}
