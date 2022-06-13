using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ELibrary.Model;

namespace ELibrary.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BoMonsController : ControllerBase
    {
        private readonly ELibraryDbContext _context;

        public BoMonsController(ELibraryDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoMon>>> GetBoMon()
        {
            return await _context.BoMon.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BoMon>> GetBoMon_id(int id)
        {
            var boMon = await _context.BoMon.FindAsync(id);

            if (boMon == null)
            {
                return NotFound();
            }

            return boMon;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaBoMon(int id,[FromBody] BoMon boMon)
        {
            if (id != boMon.Id)
            {
                return BadRequest();
            }

            _context.Entry(boMon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }

        // POST: api/BoMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemBoMon")]
        public async Task<ActionResult<BoMon>> ThemBoMon([FromBody] BoMon boMon)
        {

            _context.BoMon.Add(boMon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoMon", new { id = boMon.Id }, boMon);
        }

        // DELETE: api/BoMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoMon(int id)
        {
            var boMon = await _context.BoMon.FindAsync(id);
            if (boMon == null)
            {
                return NotFound();
            }

            _context.BoMon.Remove(boMon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

     
    }
}
