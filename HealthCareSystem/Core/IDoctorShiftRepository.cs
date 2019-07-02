using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface IDoctorShiftRepository
    {
        Task<GetDoctorShifts> GetDoctorShifts(QueryResource query);
    }
}
