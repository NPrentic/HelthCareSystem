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
    public class AdminsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAdminRepository repository;

        public AdminsController(IMapper mapper, IAdminRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins([FromQuery] QueryResource query)
        {
            var admins =await repository.GetAdminAsync(query);

            return Ok(mapper.Map<IEnumerable<Admin>, IEnumerable<AdminResource>>(admins));
        }

        //// GET: api/Admins/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Admin>> GetAdmin(int id)
        //{
        //    var admin = await _context.Admins.FindAsync(id);

        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }

        //    return admin;
        //}

        //// PUT: api/Admins/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAdmin(int id, Admin admin)
        //{
        //    if (id != admin.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(admin).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdminExists(id))
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

        //// POST: api/Admins
        //[HttpPost]
        //public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        //{
        //    _context.Admins.Add(admin);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAdmin", new { id = admin.Id }, admin);
        //}

        //// DELETE: api/Admins/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Admin>> DeleteAdmin(int id)
        //{
        //    var admin = await _context.Admins.FindAsync(id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Admins.Remove(admin);
        //    await _context.SaveChangesAsync();

        //    return admin;
        //}

        //private bool AdminExists(int id)
        //{
        //    return _context.Admins.Any(e => e.Id == id);
        //}
    }
}
