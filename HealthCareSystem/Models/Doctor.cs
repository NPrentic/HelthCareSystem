using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public int TitleId { get; set; }

        public Title Title { get; set; }

        [Required]
        public int FacilityId { get; set; }

        public Facility Facility { get; set; }

        public int Ambulance { get; set; }

        public string Password { get; set; }

        [Required ]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<DoctorShift> DoctorShifts { get; set; }

        public Doctor()
        {
            this.Patients = new Collection<Patient>(); 
            this.Appointments = new Collection<Appointment>(); 
            this.DoctorShifts = new Collection<DoctorShift>(); 
        }
    }
}
