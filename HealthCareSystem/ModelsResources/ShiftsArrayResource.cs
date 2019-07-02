using HealthCareSystem.Models;
using HealthCareSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class ShiftsArrayResource
    {
        public int EmployeeId { get; set; }

        public string Shift { get; set; }

        public DateRange DateRange { get; set; }

        public bool IsDoctor { get; set; }

        //Maps DoctorShiftsArrayResource to list of DoctorShift
        public List<DoctorShift> ConvertToDoctorShiftsArray()
        {
            var dates = new List<DateTime>();
            var doctorShifts = new List<DoctorShift>();

            var beginDate = this.DateRange.Begin.AddHours(2);
            var endDate = this.DateRange.End.AddHours(2);
            while (beginDate != endDate)
            {
                dates.Add(beginDate);
                beginDate = beginDate.AddDays(1);
            }
            dates.Add(endDate);

            foreach (var date in dates)
            {
                    doctorShifts.Add(new DoctorShift() { DoctorId = this.EmployeeId, Date = date, Shift=this.Shift });   
            }
            return doctorShifts;
        }

        public List<TehnicianShift> ConvertToTehnicianShiftsArray()
        {
            var dates = new List<DateTime>();
            var tehnicianShifts = new List<TehnicianShift>();

            var beginDate = this.DateRange.Begin.AddHours(2);
            var endDate = this.DateRange.End.AddHours(2);
            while (beginDate != endDate)
            {
                beginDate = beginDate.AddDays(1);
                dates.Add(beginDate);
            }
            dates.Add(endDate);

            foreach (var date in dates)
            {
                tehnicianShifts.Add(new TehnicianShift() { TehnicianId = this.EmployeeId, Date = date, Shift = this.Shift });
            }
            return tehnicianShifts;
        }
    }
}
