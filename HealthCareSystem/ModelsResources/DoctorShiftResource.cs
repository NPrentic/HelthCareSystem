using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Resources
{
    public class DoctorShiftResource
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int DoctorId { get; set; }

        public DoctorResource Doctor { get; set; }

        public string Shift { get; set; }
    }
}
