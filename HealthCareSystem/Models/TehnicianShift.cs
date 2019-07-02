using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class TehnicianShift
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int TehnicianId { get; set; }

        public Tehnician Tehnician { get; set; }

       [Required, StringLength(30)]
        public string Shift { get; set; }

    }
}
