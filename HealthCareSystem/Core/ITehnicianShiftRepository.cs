using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface ITehnicianShiftRepository
    {
        Task<GetTehnicianShifts> GetTehnicianShiftsAsync(QueryResource query);
    }
}
