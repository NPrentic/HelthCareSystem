using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface IShiftRepository
    {
        Task<DoctorShift> GetDoctorShiftAsync(int id);

        Task<TehnicianShift> GetTehnicianShiftAsync(int id);

        Task CreateDoctorShift(DoctorShift doctorShift);

        Task CreateTehnicianShift(TehnicianShift tehnicianShift);

        Task<List<Time>> GetTimesForParticularShift(string shift);
    }
}
