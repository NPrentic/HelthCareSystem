using HealthCareSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class AdminResource
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FacilityId { get; set; }

        public string Password { set; get; }

        public FacilityResource Facility { get; set; }

        public int RoleId { get; set; }

    }
}
