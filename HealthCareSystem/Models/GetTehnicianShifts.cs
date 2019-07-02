using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class GetTehnicianShifts
    {
        public int ItemsNumber { get; set; }

        public IEnumerable<TehnicianShift> TehnicianShifts { get; set; }
    }
}
