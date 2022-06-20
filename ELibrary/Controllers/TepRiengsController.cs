using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ELibrary.Model;

namespace ELibrary.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TepRiengsController : ControllerBase
    {
        private readonly ELibraryDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TepRiengsController(ELibraryDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/TepRiengs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TepRieng>>> Tep()
        {
            return await _context.TepRieng.ToListAsync();
        }

        // GET: api/TepRiengs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TepRieng>> Tep(int id)
        {
            var tep = await _context.TepRieng.FindAsync(id);

            if (tep == null)
            {
                return NotFound();
            }

            return tep;
        }
        //
        [HttpGet]
        [Route("/TepRiengTu")]
        public async Task<ActionResult<IEnumerable<TepRieng>>> XemTep()
        {
            var result = (from a in _context.TepRieng
                          where a.LoaiTep.Equals("Tệp riêng tư")
                          select new
                          {
                              TheLoai = a.TheLoai,
                              Ten = a.TenTep,
                              NguoiChinhSuaCuoi = a.NguoiChinhSua,
                              NgaySuaCuoi = a.NgaySuaCuoi,
                              KichThuc = a.KichThuoc
                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("LocTepRiengTu")]
        public async Task<ActionResult<TepRieng>> LocTepRieng(string loaiTep)
        {
            loaiTep = loaiTep.ToLower();
            var result = (from a in _context.TepRieng
                          where a.TheLoai.ToLower().Contains(loaiTep) && a.LoaiTep.Equals("Tệp riêng tư")
                         select new
                         {
                             TheLoai = a.TheLoai,
                             Ten = a.TenTep,
                             NguoiChinhSuaCuoi = a.NguoiChinhSua,
                             NgaySuaCuoi = a.NgaySuaCuoi,
                             KichThuc = a.KichThuoc
                         }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/TimTepRiengTu")]
        public async Task<ActionResult<TepRieng>> TimTepRt(string tukhoa)
        {
            tukhoa = tukhoa.ToLower();
            var result = (from a in _context.TepRieng
                          where a.TenTep.ToLower().Contains(tukhoa) && a.LoaiTep.Equals("Tệp riêng tư")
                          select new {
                              TheLoai=a.TheLoai,
                              Ten=a.TenTep,
                              NguoiChinhSuaCuoi=a.NguoiChinhSua,
                              NgaySuaCuoi=a.NgaySuaCuoi,
                              KichThuc=a.KichThuoc
                          }).ToList();
            return Ok(result);
        }

        // PUT: api/TepRiengs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTep(int id, string tenTep)
        {
            var tep = await _context.TepRieng.FindAsync(id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TepExists(id))
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

   

        // POST: api/TepRiengs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemTepRiengTu")]
        public async Task<ActionResult<TepRieng>> ThemTep([FromForm] TepRieng tep)
        {
            
            tep.NguoiChinhSua = "";
            tep.NgaySuaCuoi = DateTime.Now;
            tep.LoaiTep = "Tệp riêng tư";

            if (tep.File != null)
            {
                _context.TepRieng.Add(tep);

            }
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("Tep", new { id = tep.Id }, tep);
        }

        // DELETE: api/TepRiengs/5
        [HttpDelete]
        [Route("/XoaTepRiengTu/{id}")]
        public async Task<IActionResult> XoaTep(int id)
        {
            var tep = await _context.TepRieng.FindAsync(id);
            if (tep == null)
            {
                return NotFound();
            }

            _context.TepRieng.Remove(tep);
           
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool TepExists(int id)
        {
            return _context.TepRieng.Any(e => e.Id == id);
        }
    }
}
