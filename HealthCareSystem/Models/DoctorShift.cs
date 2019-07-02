using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class DoctorShift
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required, StringLength(30)]
        public string Shift { get; set; }

    }
}
