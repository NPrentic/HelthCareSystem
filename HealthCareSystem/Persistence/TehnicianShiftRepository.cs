using HealthCareSystem.Core;
using HealthCareSystem.DbContextFolder;
using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Persistence
{
    public class TehnicianShiftRepository : ITehnicianShiftRepository
    {
        private readonly AppDbContext context;

        public TehnicianShiftRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<GetTehnicianShifts> GetTehnicianShiftsAsync(QueryResource query)
        {
            var shifts = await this.context.TehniciansShifts.Include(s => s.Tehnician).ToListAsync();
            var result = new GetTehnicianShifts();

            if (query.TehnicianId.HasValue)
            {
                shifts = shifts.FindAll(s => s.TehnicianId == query.TehnicianId);
            }

            if (query.FacilityId != null)
            {
                shifts = shifts.FindAll(s => s.Tehnician.FacilityId == int.Parse(query.FacilityId));
            }
            shifts = shifts.OrderBy(s => s.Date).ToList();

            if (query.Page <= 0)
            {
                query.Page = 1;
            }
            if (query.PageSize <= 0)
            {
                query.PageSize = shifts.Count();
            }

            result.ItemsNumber = shifts.Count();

            shifts = shifts.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize).ToList();

            result.TehnicianShifts = shifts;

            return result;
        }
    }
}
