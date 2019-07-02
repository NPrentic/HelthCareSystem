using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareSystem.Models;
using AutoMapper;
using HealthCareSystem.Core;
using HealthCareSystem.Resources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPatientRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PatientsController(IMapper mapper, IPatientRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] string cardNumber)
        {
            var patient = await repository.GetPatientsAsync(cardNumber);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Patient,PatientResource>(patient));
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = await repository.GetPatientAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Patient,PatientResource>(patient));
        }

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient([FromRoute] int id,[FromBody] PatientResource patientResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = mapper.Map<PatientResource, Patient>(patientResource);
            repository.UpdatePatient(patient);

            try
            {
                await unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/Patients
        //[HttpPost]
        //public async Task<IActionResult> PostPatient([FromBody] Patient patient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Patients.Add(patient);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        //}

        //// DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = await repository.GetPatientAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            repository.DeletePatient(patient);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        private bool PatientExists(int id)
        {
            var patient = repository.GetPatientAsync(id);
            if (patient == null) return false;
            return true;
        }
    }
}