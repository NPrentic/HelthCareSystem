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
    public class TitleRepository :ITitleRepository
    {
        private readonly AppDbContext context;

        public TitleRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Title> GetTitleAsync(int titleId)
        {
            var title = await context.Titles.FindAsync(titleId);

            return title;
        }

        public async Task<IEnumerable<Title>> GetTitlesAsync()
        {
            var titles = await context.Titles.ToListAsync();
            return titles;
        }


    }
}
