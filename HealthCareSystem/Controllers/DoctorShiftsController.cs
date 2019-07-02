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
using HealthCareSystem.Resources;
using HealthCareSystem.ModelsResources;
using System.Collections.ObjectModel;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorShiftsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDoctorShiftRepository repository;

        public DoctorShiftsController( IMapper mapper, IDoctorShiftRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        //// GET: api/DoctorShifts
        [HttpGet]
        public async Task<ActionResult<GetDoctorShiftsResource>> GetDoctorShifts([FromQuery] QueryResource query)
        {
            var result = await repository.GetDoctorShifts(query);

            return Ok(mapper.Map<GetDoctorShifts, GetDoctorShiftsResource>(result));
        }

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

        //// POST: api/DoctorShifts
        //[HttpPost]
        //public async Task<ActionResult<DoctorShift>> PostDoctorShift(DoctorShift doctorShift)
        //{
        //    _context.DoctorShifts.Add(doctorShift);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDoctorShift", new { id = doctorShift.Id }, doctorShift);
        //}

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
