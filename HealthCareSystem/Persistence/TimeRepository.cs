using HealthCareSystem.Core;
using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.DbContextFolder;

namespace HealthCareSystem.Persistence
{
    public class TimeRpeository : ITimeRepository
    {
        private readonly AppDbContext context;

        public TimeRpeository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Time> GetTimeAsync(int timeId)
        {
            var time = await context.Times.FindAsync(timeId);

            return time;
        }

        public async Task<IEnumerable<Time>> GetTimesAsync()
        {
            var times = await context.Times.ToListAsync();
            return times;
          
        }
    }
}
