using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareSystem.Models;
using AutoMapper;
using HealthCareSystem.Core;
using HealthCareSystem.Resources;
using HealthCareSystem.ModelsResources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAppointmentRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public AppointmentsController(
            IMapper mapper, 
            IAppointmentRepository repository, 
            IUnitOfWork unitOfWork, 
            IPatientRepository patientRepository)
        {  
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<IEnumerable<AppointmentResource>> GetAppointments([FromQuery] QueryResource query)
        {
           
             var appointments =  await this.repository.GetAppointmentsAsync(query);

            return mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);

        }    
        // GET: api/Appointments
        [HttpPost]
        public async Task<IEnumerable<AppointmentResource>> GetApp([FromBody] QueryResource query)
        {
           
             var appointments =  await this.repository.GetScheduledAppointmentsAsync(query);

            return mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);

        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = await repository.GetAppointmentAsync(id);
            var appointmentResource = mapper.Map<Appointment, AppointmentResource>(appointment);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointmentResource);
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment([FromRoute] int id, [FromBody] AppointmentResource appointmentResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResource.Id)
            {
                return BadRequest();
            }

            var appointment = await repository.GetAppointmentAsync(id);

            // Kada zalimo da zakazemo pregled u neki slobodan termin 
            if (appointmentResource.TimeId == 0) {
                appointment.PatientId = appointmentResource.PatientId;
            }
            // Kada zelimo da otkazemo dati pregled i ucinimo termin ponovo slobodnim
            if (appointmentResource.PatientId == 0)
              {
                appointment.PatientId = 0;
             }
          
            repository.UpdateAppointment(appointment);
            try
            {
                await unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: api/Appointments
        //[HttpPost]
        //public async Task<IActionResult> PostAppointment([FromBody] AppointmentsDetailsResource appointmentsDetails)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var appointments =appointmentsDetails.ConvertToAppointmentsArray();

        //    foreach (var appointment  in appointments)
        //    {
        //        this.repository.CreateAppointment(appointment);
        //        await this.unitOfWork.CompleteAsync();
        //    }

        //    var response = new List<Appointment>();
        //    foreach (var appointment in appointments)
        //    {
        //        response.Add(await this.repository.GetAppointmentAsync(appointment.Id));
        //    }
        //    return Ok(mapper.Map<IEnumerable<Appointment>,IEnumerable<AppointmentResource>>(response));
        //}

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = await repository.GetAppointmentAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            repository.DeleteAppointment(appointment);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        private bool AppointmentExists(int id)
           {
            var appointment = repository.GetAppointmentAsync(id);
            if (appointment == null) return false;
            return true;
        }
    }
}