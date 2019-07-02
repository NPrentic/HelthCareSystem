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
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext context;

        public AdminRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Admin>> GetAdminAsync()
        {
            var admins = await context.Admins.Include(a => a.Facility).Include(a => a.Role).ToListAsync();

            return admins;
        }
         public async Task<IEnumerable<Admin>> GetAdminAsync(QueryResource query)
        {
            var admins = await context.Admins.Include(a => a.Facility).ToListAsync();

            if (query.UserId != 0) { admins = admins.FindAll(a => a.UserId == query.UserId); }

            return admins;
        }

    }
}
