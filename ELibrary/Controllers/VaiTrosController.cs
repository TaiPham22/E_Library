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
    public class VaiTrosController : ControllerBase
    {
        private readonly ELibraryDbContext _context;

        public VaiTrosController(ELibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/VaiTros
        [HttpGet]
        [Route("/NhomNguoiDung")]
        public async Task<ActionResult<IEnumerable<VaiTro>>> VaiTro()
        {
            var result = (from a in _context.VaiTro
                          select new {
                              TenNhom=a.TenVaiTro,
                              MoTa=a.MoTa,
                              NgayCapNhatCuoi=a.NgayCapNhatCuoi
                          }).ToList();
            return Ok(result);
        }

        // GET: api/VaiTros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaiTro>> VaiTro(int id)
        {
            var result = await _context.VaiTro.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/VaiTros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaVaiTro(int id, [FromBody] VaiTro vaiTro)
        {
            if (id != vaiTro.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaiTro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaiTroExists(id))
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
      
        [HttpPost]
        [Route("themvaitro")]
        public async Task<ActionResult<VaiTro>> ThemVaiTro([FromForm] VaiTro vaiTro, [FromForm] int[] phanQuyen)
        {
            vaiTro.NgayCapNhatCuoi = DateTime.Now;
            _context.VaiTro.Add(vaiTro);
            await _context.SaveChangesAsync();
           
            if (phanQuyen.Count() > 0)
            {
                foreach (int a in phanQuyen)
                {
                    var result = new VaiTroPhanQuyen();
                    result.VaiTroId = vaiTro.Id;
                    result.PhanQuyenId = a;
                    _context.VaiTroPhanQuyen.Add(result);
                    await _context.SaveChangesAsync();
                }
                return Ok("Cai dat thanh cong");
            }

            return CreatedAtAction("GetVaiTro", new { id = vaiTro.Id }, vaiTro);
        }
        [HttpPost]
        [Route("caidatvaitro")]
        public async Task<ActionResult<VaiTro>> CaiDatVaiTro([FromForm] int[] phanQuyen,[FromForm] int vaiTro)
        {
            var result = await _context.VaiTroPhanQuyen.Where(v => v.VaiTroId == vaiTro).ToListAsync();
            foreach (var x in result)
            {
                _context.VaiTroPhanQuyen.Remove(x);
                await _context.SaveChangesAsync();
            }
            if (phanQuyen.Count()>0)
            {
                foreach(int a in phanQuyen)
                {
                    var quyen = new VaiTroPhanQuyen();
                    quyen.VaiTroId = vaiTro;
                    quyen.PhanQuyenId = a;
                    _context.VaiTroPhanQuyen.Add(quyen);
                    await _context.SaveChangesAsync();
                }
                var role = await _context.VaiTro.FindAsync(vaiTro);
                role.NgayCapNhatCuoi = DateTime.Now;
                _context.Update(role);
                await _context.SaveChangesAsync();
                return Ok("Cai dat thanh cong");
            }
            return NoContent();
        }

        // DELETE: api/VaiTros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaVaiTro(int id)
        {
            var result = await _context.VaiTro.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.VaiTro.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaiTroExists(int id)
        {
            return _context.VaiTro.Any(e => e.Id == id);
        }
    }
}
