using HealthCareSystem.Core;
using HealthCareSystem.DbContextFolder;
using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Persistence
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext context;
        private readonly ITimeRepository timeRepository;
        private readonly IDoctorShiftRepository doctorShiftRepository;

        public ShiftRepository(AppDbContext context, ITimeRepository timeRepository, IDoctorShiftRepository doctorShiftRepository)
        {
            this.context = context;
            this.timeRepository = timeRepository;
            this.doctorShiftRepository = doctorShiftRepository;
        }

        public async Task CreateDoctorShift(DoctorShift doctorShift)
        {
            var query = new QueryResource() { DoctorId = doctorShift.DoctorId };

            var previouslyUpdatedDates = new List<DateTime>();
            var previouslyUpdatedShifts = await doctorShiftRepository.GetDoctorShifts(query);
            previouslyUpdatedDates = previouslyUpdatedShifts.DoctorShifts.Select(d=>d.Date).ToList();
            if(!previouslyUpdatedDates.Contains(doctorShift.Date))
            this.context.DoctorShifts.Add(doctorShift);
        }

        public async Task CreateTehnicianShift(TehnicianShift tehnicianShift)
        {
            tehnicianShift.Date.AddHours(2);

            this.context.TehniciansShifts.Add(tehnicianShift);
        }

        public async Task<DoctorShift> GetDoctorShiftAsync(int id)
        {
            return await context.DoctorShifts.FindAsync(id);
        }

        public async Task<TehnicianShift> GetTehnicianShiftAsync(int id)
        {
            return await context.TehniciansShifts.FindAsync(id);
        }


        public async Task<List<Time>> GetTimesForParticularShift(string shift) {

            var Times = await this.timeRepository.GetTimesAsync();
            var Times2 = Times.ToList();

            var particularTimes = new List<Time>();

            if (shift.ToLower() == "first")
            {
                for (int i = 0; i < Times2.Count() / 2; i++)
                {
                    particularTimes.Add(Times2[i]);
                }
            }
            if (shift.ToLower() == "second")
            {
                for (int i = Times2.Count() / 2; i < Times2.Count() ; i++)
                {
                    particularTimes.Add(Times2[i]);
                }
            }
            if (shift.ToLower() == "midshift")
            {
                for (int i = Times2.Count() / 4 +1; i < Times2.Count() - Times2.Count() / 4 +1; i++)
                {
                    particularTimes.Add(Times2[i]);
                }
            }
            return particularTimes;
        }


    }
}
