using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required, StringLength(20)]
        public string Gender { get; set; }

        [Required, StringLength(50)]
        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(50)]
        public string FatherName { get; set; }

        [Required, StringLength(30)]
        public string BloodType { get; set; }

        [Required, StringLength(13)]
        public string CardNumber { get; set; }

        [Required]
        public bool HasAppointment { get; set; }

    }
}
