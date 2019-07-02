using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthCareSystem.Models;
using AutoMapper;
using HealthCareSystem.Core;
using HealthCareSystem.Resources;
using HealthCareSystem.ModelsResources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IShiftRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAppointmentRepository appointmentRepository;

        public  ShiftsController(
            IMapper mapper,
            IShiftRepository repository,
            IUnitOfWork unitOfWork,
            IAppointmentRepository appointmentRepository
           )
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.appointmentRepository = appointmentRepository;

        }

        // GET: api/Shifts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DoctorShift>>> GetDoctorShifts()
        //{
        //    return await repository.GetDoctorShiftAsync();
        //}

        //// GET: api/DoctorShifts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DoctorShift>> GetDoctorShift(int id)
        //{
        //    var doctorShift = await _context.DoctorShifts.FindAsync(id);

        //    if (doctorShift == null)
        //    {
        //        return NotFound();
        //    }

        //    return doctorShift;
        //}

        //// PUT: api/DoctorShifts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDoctorShift(int id, DoctorShift doctorShift)
        //{
        //    if (id != doctorShift.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(doctorShift).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DoctorShiftExists(id))
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

        // POST: api/DoctorShifts
        [HttpPost]
        public async Task<ActionResult<DoctorShift>> PostDoctorShift(ShiftsArrayResource ShiftArrayResource)
        {
            if (ShiftArrayResource.IsDoctor)
            {
                var doctorShifts = ShiftArrayResource.ConvertToDoctorShiftsArray();

                foreach (var doctorShift in doctorShifts)
                {
                      await  this.repository.CreateDoctorShift(doctorShift);
                        var particularTimes = await this.repository.GetTimesForParticularShift(doctorShift.Shift);

                        foreach (var time in particularTimes)
                        {
                            this.appointmentRepository.CreateAppointment(
                           new Appointment() { Date = doctorShift.Date, PatientId = 0, DoctorId = doctorShift.DoctorId, TimeId = time.Id });
                        }
                    
                }
                await this.unitOfWork.CompleteAsync();

                var response = new List<DoctorShift>();
                foreach (var doctorShift in doctorShifts)
                {
                    response.Add(await this.repository.GetDoctorShiftAsync(doctorShift.Id));
                }
                return Ok(mapper.Map<IEnumerable<DoctorShift>, IEnumerable<DoctorShiftResource>>(response));
            }
            else {
                var tehnicianshifts = ShiftArrayResource.ConvertToTehnicianShiftsArray();

                foreach (var tehnicianShift in tehnicianshifts)
                {
                   this.repository.CreateTehnicianShift(tehnicianShift);
                }
                await this.unitOfWork.CompleteAsync();

                var response = new List<TehnicianShift>();
                foreach (var tehnicianShift in tehnicianshifts)
                {
                    response.Add(await this.repository.GetTehnicianShiftAsync(tehnicianShift.Id));
                }
                return Ok(mapper.Map<IEnumerable<TehnicianShift>, IEnumerable<TehnicianShiftResource>>(response));
            }
        }

        //// DELETE: api/DoctorShifts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DoctorShift>> DeleteDoctorShift(int id)
        //{
        //    var doctorShift = await _context.DoctorShifts.FindAsync(id);
        //    if (doctorShift == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DoctorShifts.Remove(doctorShift);
        //    await _context.SaveChangesAsync();

        //    return doctorShift;
        //}

        //private bool DoctorShiftExists(int id)
        //{
        //    return _context.DoctorShifts.Any(e => e.Id == id);
        //}
    }
}
