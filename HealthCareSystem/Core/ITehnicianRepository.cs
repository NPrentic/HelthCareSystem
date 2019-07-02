using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface ITehnicianRepository
    {
        void CreateTehnician(Tehnician tehnician);

        Task<Tehnician> GetTehnicianAsync(int tehnicianId);

        Task<IEnumerable<Tehnician>> GetTehniciansAsync();

        Task<GetTehnicians> GetTehniciansAsync(QueryResource query);

        void DeleteTehnician(Tehnician tehnician);
    }
}
