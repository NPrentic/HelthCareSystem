using HealthCareSystem.ModelsResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Resources
{
    public class DoctorResource
    {
        public int Id { get; set; }

     
        public string Name { get; set; }

        public int TitleId { get; set; }

        public TitleResource Title { get; set; }

        public int FacilityId { get; set; }

        public FacilityResource Facility { get; set; }

        public int Ambulance { get; set; }

        public int UserId { get; set; }

        public string Password { set; get; }

        public int RoleId { get; set; }

        public RoleResource Role { get; set; }

        public ICollection<PatientResource> Patients { get; set; }

        public ICollection<AppointmentResource> Appointments { get; set; }

        public ICollection<DoctorShiftResource> DoctorShifts { get; set; }


        public DoctorResource()
        {
            this.Patients = new Collection<PatientResource>();
            this.Appointments = new Collection<AppointmentResource>();
            this.DoctorShifts = new Collection<DoctorShiftResource>();
        }
    }
}
