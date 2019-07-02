using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareSystem.DbContextFolder;
using HealthCareSystem.Models;
using AutoMapper;
using HealthCareSystem.Core;
using HealthCareSystem.ModelsResources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TehniciansController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITehnicianRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public TehniciansController(IMapper mapper, ITehnicianRepository repository,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Tehnicians
        [HttpGet]
        public async Task<GetTehniciansResult> GetTehnicians([FromQuery] QueryResource query)
        {
            var result = await this.repository.GetTehniciansAsync(query);

            return mapper.Map<GetTehnicians, GetTehniciansResult>(result);
        }

        // GET: api/Tehnicians/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTehnician([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tehnician = await this.repository.GetTehnicianAsync(id);

            if (tehnician == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Tehnician, TehnicianResource>(tehnician));
        }

        //// PUT: api/Tehnicians/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTehnician(int id, Tehnician tehnician)
        //{
        //    if (id != tehnician.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tehnician).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TehnicianExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Tehnicians
        [HttpPost]
        public async Task<ActionResult<Tehnician>> PostTehnician(TehnicianResource tehnicianResource)
        {
            tehnicianResource.RoleId = 4; //4- Tehnician
            var tehnician = mapper.Map<TehnicianResource, Tehnician>(tehnicianResource);

            this.repository.CreateTehnician(tehnician);
            await this.unitOfWork.CompleteAsync();

            tehnician = await this.repository.GetTehnicianAsync(tehnician.Id);

            return Ok(mapper.Map<Tehnician, TehnicianResource>(tehnician));
        }

        //// DELETE: api/Tehnicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTehnician([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctor = await repository.GetTehnicianAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            repository.DeleteTehnician(doctor);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
