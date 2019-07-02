using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class GetDoctorShifts
    {
        public int ItemsNumber { get; set; }

        public IEnumerable<DoctorShift> DoctorShifts { get; set; }
    }
}
