using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Tehnician
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int FacilityId { get; set; }

        public Facility Facility { get; set; }

        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

    }
}
