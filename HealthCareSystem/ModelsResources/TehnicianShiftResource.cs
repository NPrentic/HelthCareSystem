using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class TehnicianShiftResource
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

       
        public int TehnicianId { get; set; }

        public Tehnician Tehnician { get; set; }

     
        public string Shift { get; set; }
    }
}
