using HealthCareSystem.Core;
using HealthCareSystem.Models;
using HealthCareSystem.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.DbContextFolder;

namespace HealthCareSystem.Persistence
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly AppDbContext context;

        public FacilityRepository(AppDbContext context )
        {
            this.context = context;
        }

        public async Task<IEnumerable<Facility>> GetFacilitiesAsync()
        {
            var facilities = await context.Facilities.ToListAsync();
            return facilities;
        }

        public async Task<Facility> GetFacilityAsync(int facilityId)
        {
            var facility = await context.Facilities.FindAsync(facilityId);

            return facility;
        }
    }
}
