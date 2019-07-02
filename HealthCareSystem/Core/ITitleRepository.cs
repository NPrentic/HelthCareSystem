using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
  public  interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetTitlesAsync();

        Task<Title> GetTitleAsync(int titleId);
    }
}
