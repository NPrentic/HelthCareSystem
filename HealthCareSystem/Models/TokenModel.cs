using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class TokenModel
    {   
        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public Facility Facility { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
