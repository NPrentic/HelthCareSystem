using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class GetTehnicians
    {
        public IEnumerable<Tehnician> Tehnicians { get; set; }


        public int ItemsNumber { get; set; }
    }
}
