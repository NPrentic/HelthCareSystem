﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class DoctorQuery
    {
        public string FacilityId { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }

    }
}
