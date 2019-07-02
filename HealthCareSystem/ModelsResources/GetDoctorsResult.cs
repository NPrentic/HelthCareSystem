﻿using HealthCareSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class GetDoctorsResult
    {
        public IEnumerable<DoctorResource> Doctors { get; set; }

        public int ItemsNumber { get; set; }

    }
}
