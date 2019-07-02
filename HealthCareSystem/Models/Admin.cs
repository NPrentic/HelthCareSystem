using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int FacilityId { get; set; }

        public Facility Facility { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

    }
}
