using HealthCareSystem.Models;
using HealthCareSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface IFacilityRepository
    {
        Task<IEnumerable<Facility>> GetFacilitiesAsync();

        Task<Facility> GetFacilityAsync(int facilityId);
    }
}
