using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareSystem.Models;
using HealthCareSystem.DbContextFolder;
using AutoMapper;
using HealthCareSystem.Core;
using HealthCareSystem.Resources;
using HealthCareSystem.ModelsResources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDoctorRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITitleRepository titleRepository;

        public DoctorsController(IMapper mapper, IDoctorRepository repository,IUnitOfWork unitOfWork, ITitleRepository titleRepository)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.titleRepository = titleRepository;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<GetDoctorsResult> GetDoctors([FromQuery] QueryResource query)
        {
            var doctors = await this.repository.GetDoctorsAsync(query);

            var result = new GetDoctorsResult() { ItemsNumber = doctors.Count() };

            if (query.Page <= 0)
                query.Page = 1;
            if (query.PageSize <= 0)
            {
                query.PageSize = doctors.Count();
            }

            doctors = doctors.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
            result.Doctors = mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);
            return result;
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctor = await this.repository.getDoctorAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Doctor,DoctorResource>(doctor));
        }

        //// PUT: api/Doctors/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDoctor([FromRoute] int id, [FromBody] Doctor doctor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != doctor.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(doctor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DoctorExists(id))
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

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> PostDoctor([FromBody] DoctorResource doctorResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await this.titleRepository.GetTitleAsync(doctorResource.TitleId);
            doctorResource.RoleId = title.IsSpecialist? 3 : 2; // 3: nonSpecialist, 2: Specialist

            var doctor = mapper.Map<DoctorResource, Doctor>(doctorResource);

            this.repository.CreateDoctor(doctor);
            await this.unitOfWork.CompleteAsync();

            doctor = await this.repository.getDoctorAsync(doctor.Id);

            return Ok(mapper.Map<Doctor,DoctorResource>(doctor));
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctor = await repository.getDoctorAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            repository.DeleteDoctor(doctor);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        //private bool DoctorExists(int id)
        //{
        //    return _context.Doctors.Any(e => e.Id == id);
        //}
    }
}