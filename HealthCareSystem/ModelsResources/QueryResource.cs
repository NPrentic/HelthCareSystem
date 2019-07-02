using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class QueryResource
    {
        public string FacilityId { get; set; }

        public int? DoctorId { get; set; }

        public int? TehnicianId { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public int PatientId { get; set; }

        public DateTime? Date { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }

    }
}
