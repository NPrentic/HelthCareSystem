using HealthCareSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class GetTehnicianShiftsResult
    {
        public int ItemsNumber { get; set; }

        public IEnumerable<TehnicianShiftResource> TehnicianShifts { get; set; }
    }
}
