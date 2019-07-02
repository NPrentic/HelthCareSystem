using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class TehnicianResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FacilityId { get; set; }

        public string Gender { get; set; }

        public int UserId { get; set; }

        public string Password { set; get; }

        public int RoleId { get; set; }

        public RoleResource Role { get; set; }
    }
}
