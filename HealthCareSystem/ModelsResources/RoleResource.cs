using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.ModelsResources
{
    public class RoleResource
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
    }
}
