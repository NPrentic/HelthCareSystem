using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthCareSystem.Models;
using AutoMapper;
using HealthCareSystem.Core;
using HealthCareSystem.ModelsResources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TehnicianShiftsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITehnicianShiftRepository repository;

        public TehnicianShiftsController(IMapper mapper, ITehnicianShiftRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        // GET: api/TehnicianShifts
        [HttpGet]
        public async Task<ActionResult<GetTehnicianShiftsResult>> GetTehnicianShifts([FromQuery] QueryResource query)
        {
            var result = await repository.GetTehnicianShiftsAsync(query);

            return Ok(mapper.Map<GetTehnicianShifts, GetTehnicianShiftsResult>(result));
        }
    }
}
