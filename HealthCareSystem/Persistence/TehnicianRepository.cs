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
    public class TehnicianRepository : ITehnicianRepository
    {
        private readonly AppDbContext context;

        public TehnicianRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateTehnician(Tehnician tehnician)
        {
            this.context.Add(tehnician);
        }

        public void DeleteTehnician(Tehnician tehnician)
        {
            this.context.Remove(tehnician);
        }

        public async Task<Tehnician> GetTehnicianAsync(int tehnicianId)
        {
            var tehnician = await this.context.Tehnicians.FindAsync(tehnicianId);
            return tehnician;
        }

        public async Task<IEnumerable<Tehnician>> GetTehniciansAsync()
        {
            var tehnicians = await this.context.Tehnicians.Include(t=>t.Facility).Include(t => t.Role).ToListAsync();
            return tehnicians;
        }

        public async Task<GetTehnicians> GetTehniciansAsync(QueryResource query)
        {
            var tehnicians = await this.context.Tehnicians.ToListAsync();

            if (query.FacilityId != null) { tehnicians = tehnicians.FindAll(d => d.FacilityId.ToString() == query.FacilityId);}

            if (query.UserId != 0) { tehnicians = tehnicians.FindAll(d => d.UserId == query.UserId);}


            if (query.Page <= 0)
            {
                query.Page = 1;
            }
            if (query.PageSize <= 0)
            {
                query.PageSize = tehnicians.Count();
            }

            var result = new GetTehnicians();

            result.ItemsNumber = tehnicians.Count();

            tehnicians = tehnicians.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize).ToList();

            result.Tehnicians = tehnicians;

            return result;
        }
    }
}
