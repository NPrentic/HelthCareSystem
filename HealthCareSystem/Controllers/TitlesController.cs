using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareSystem.Models;
using HealthCareSystem.DbContextFolder;
using HealthCareSystem.Core;
using AutoMapper;
using HealthCareSystem.Resources;

namespace HealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleRepository repository;
        private readonly IMapper mapper;

        public TitlesController(ITitleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/Titles
        [HttpGet]
        public async Task<IEnumerable<TitleResource>> GetTitles()
        {
            return mapper.Map<IEnumerable<Title>, IEnumerable<TitleResource>>(await this.repository.GetTitlesAsync());
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await this.repository.GetTitleAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Title,TitleResource>(title));
        }

        //// PUT: api/Titles/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTitle([FromRoute] int id, [FromBody] Title title)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != title.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(title).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TitleExists(id))
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

        //// POST: api/Titles
        //[HttpPost]
        //public async Task<IActionResult> PostTitle([FromBody] Title title)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Titles.Add(title);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        //}

        //// DELETE: api/Titles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var title = await _context.Titles.FindAsync(id);
        //    if (title == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Titles.Remove(title);
        //    await _context.SaveChangesAsync();

        //    return Ok(title);
        //}

        //private bool TitleExists(int id)
        //{
        //    return _context.Titles.Any(e => e.Id == id);
        //}
    }
}