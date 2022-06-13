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
    public class TroGiupsController : ControllerBase
    {
        private readonly ELibraryDbContext _context;

        public TroGiupsController(ELibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/TroGiups
        [HttpGet]
        [Route("/TroGiup")]
        public async Task<ActionResult<IEnumerable<TroGiup>>> GetTroGiup()
        {

            return await _context.TroGiup.ToListAsync();
        }

        // GET: api/TroGiups/5
        [HttpGet("{id}")]

        public async Task<ActionResult<TroGiup>> GetTroGiup(int id)
        {
            var result = await _context.TroGiup.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        

        // POST: api/TroGiups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/TroGiup")]
        public async Task<ActionResult<TroGiup>> PostTroGiup([FromForm] TroGiup troGiup)
        {
            troGiup.TaiKhoanId = HttpContext.Session.GetString("Nd");
            _context.TroGiup.Add(troGiup);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTroGiup", new { id = troGiup.Id }, troGiup);
        }

        // DELETE: api/TroGiups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTroGiup(int id)
        {
            var result = await _context.TroGiup.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.TroGiup.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TroGiupExists(int id)
        {
            return _context.TroGiup.Any(e => e.Id == id);
        }
    }
}
