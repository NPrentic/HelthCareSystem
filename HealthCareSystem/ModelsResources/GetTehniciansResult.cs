using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class GetTehniciansResult
    {
        public IEnumerable<TehnicianResource> Tehnicians { get; set; }

        public int ItemsNumber { get; set; }

    }
}
