using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareSystem.Models;
using HealthCareSystem.Core;
using AutoMapper;
using HealthCareSystem.Resources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimeRepository repository;
        private readonly IMapper mapper;

        public TimesController(ITimeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET: api/Times
        [HttpGet]
        public async Task<IEnumerable<TimeResource>> GetTimes()
        {
            return mapper.Map<IEnumerable<Time>, IEnumerable<TimeResource>>(await this.repository.GetTimesAsync());
        }

        // GET: api/Times/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTime([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var time = await this.repository.GetTimeAsync(id);

            if (time == null)
            {
                return NotFound();
            }
            return Ok(this.mapper.Map<Time,TimeResource>(time));
        }

        //// PUT: api/Times/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTime([FromRoute] int id, [FromBody] Time time)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != time.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(time).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TimeExists(id))
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

        //// POST: api/Times
        //[HttpPost]
        //public async Task<IActionResult> PostTime([FromBody] Time time)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Times.Add(time);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTime", new { id = time.Id }, time);
        //}

        //// DELETE: api/Times/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTime([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var time = await _context.Times.FindAsync(id);
        //    if (time == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Times.Remove(time);
        //    await _context.SaveChangesAsync();

        //    return Ok(time);
        //}

        //private bool TimeExists(int id)
        //{
        //    return _context.Times.Any(e => e.Id == id);
        //}
    }
}