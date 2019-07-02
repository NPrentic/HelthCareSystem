using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Facility
    {
        public int Id { get; set; }

       [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public string City { get; set; }

        [Required, StringLength(200)]
        public string Address { get; set; }

        [Required, StringLength(200)]
        public string ContactPhone { get; set; }

       [Required, StringLength(200)]
        public string ContactEmail { get; set; }
    }
}
