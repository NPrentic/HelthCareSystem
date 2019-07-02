using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAdminAsync();
        Task<IEnumerable<Admin>> GetAdminAsync(QueryResource query);
    }
}
