using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Resources
{
    public class PatientResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DoctorId { get; set; }

        public DoctorResource Doctor { get; set; }

        public string Gender { get; set; }

      
        public DateTime DateOfBirth { get; set; }

  
        public string FatherName { get; set; }

       
        public string BloodType { get; set; }

 
        public string CardNumber { get; set; }


        public bool HasAppointment { get; set; }

    }
}
