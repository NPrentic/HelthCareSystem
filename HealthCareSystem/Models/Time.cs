using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Time
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string  AppointmentTime { get; set; }

    }
}
