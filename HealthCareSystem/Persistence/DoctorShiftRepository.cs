using HealthCareSystem.Core;
using HealthCareSystem.DbContextFolder;
using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Persistence
{
    public class DoctorShiftRepository : IDoctorShiftRepository
    {
        private readonly AppDbContext context;

        public DoctorShiftRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<GetDoctorShifts> GetDoctorShifts(QueryResource query)
        {
            var shifts = await this.context.DoctorShifts.Include(s => s.Doctor).ToListAsync();
            var result = new GetDoctorShifts();

            if (query.DoctorId.HasValue)
            {
                shifts = shifts.FindAll(s => s.DoctorId == query.DoctorId);
            }

            if (query.FacilityId != null)
            {
              shifts = shifts.FindAll(s => s.Doctor.FacilityId == int.Parse(query.FacilityId));
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

            result.DoctorShifts = shifts;

            return result;
        }
    }
}
