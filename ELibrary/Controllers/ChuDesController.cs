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
    public class ChuDesController : ControllerBase
    {
        private readonly ELibraryDbContext _context;

        public ChuDesController(ELibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuDe>>> ChuDe()
        {
            return await _context.ChuDe.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuDe>> ChiTietChuDe(int id)
        {
            var chuDe = await _context.ChuDe.FindAsync(id);

            if (chuDe == null)
            {
                return NotFound();
            }

            return chuDe;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuDe(int id, ChuDe chuDe)
        {
            if (id != chuDe.Id)
            {
                return BadRequest();
            }

            _context.Entry(chuDe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        // POST: api/ChuDes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChuDe>> ThemChuDe([FromForm] ChuDe chuDe)
        {
            _context.ChuDe.Add(chuDe);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetChuDe", new { id = chuDe.Id }, chuDe);
        }

        // DELETE: api/ChuDes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaChuDe(int id)
        {
            var chuDe = await _context.ChuDe.FindAsync(id);
            if (chuDe == null)
            {
                return NotFound();
            }

            _context.ChuDe.Remove(chuDe);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

      
    }
}
