using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Resources
{
    public class AppointmentResource
    {
        public int Id { get; set; }

 
        public DateTime Date { get; set; }


        public int TimeId { get; set; }

        public TimeResource Time { get; set; }

        public int PatientId { get; set; }

        public PatientResource Patient { get; set; }

        public int DoctorId { get; set; }

        public DoctorResource Doctor { get; set; }

    }
}
