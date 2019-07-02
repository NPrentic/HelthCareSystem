using HealthCareSystem.Core;
using HealthCareSystem.Models;
using HealthCareSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Resources
{
    public class AppointmentsDetailsResource
    {
        public int DoctorId { get; set; }

        public string Shift { get; set; }

        public DateRange DateRange { get; set; }

        public IEnumerable<Time> Times { get; set; }

    }
}
