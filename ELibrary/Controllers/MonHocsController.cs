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
    public class MonHocsController : ControllerBase
    {
       
        private readonly ELibraryDbContext _context;

        public MonHocsController(ELibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMonHoc()
        {
            var result = (from a in _context.MonHoc
                          select new
                          {
                              MaMonHoc = a.Id,
                              TenMonHoc = a.TenMonHoc,
                              MoTa = a.MoTa,
                              TinhTrang = a.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/LocMonHoc")]
        public async Task<ActionResult> LocMonHoc(int tenMon, int lopHoc=-1) 
        {
            if (lopHoc < 0)
            {
                var result = (from a in _context.MonHoc
                              orderby a.TenMonHoc
                              select new
                              {
                                  MaMonHoc = a.Id,
                                  TenMonHoc = a.TenMonHoc,
                                  MoTa = a.MoTa,
                                  TinhTrang = a.TinhTrang,
                                  SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                              }).Distinct().ToList();
                return Ok(result);
            }
            else
            {
                var result = (from a in _context.LopHocMonHoc
                              join b in _context.MonHoc on a.MonHocId equals b.Id
                              join c in _context.LopHoc on a.LopHocId equals c.Id
                              orderby c.TenLop
                              select new
                              {
                                  MaMonHoc = b.Id,
                                  TenMonHoc = b.TenMonHoc,
                                  MoTa = b.MoTa,
                                  TinhTrang = b.TinhTrang,
                                  SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                              }).Distinct().ToList();
                return Ok(result);
            }
        }
        


        [HttpGet]
        [Route("/TimKiemMonHoc")]
        public async Task<ActionResult> TimKiemDsMonHoc(string tukhoa)
        {
            tukhoa = tukhoa.ToLower();
         
            var result = (from a in _context.LopHocMonHoc
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          join c in _context.LopHoc on a.LopHocId equals c.Id
                          where b.TenMonHoc.Contains(tukhoa) || c.TenLop.Contains(tukhoa)
                          select new
                          {
                              MaMonHoc = b.Id,
                              TenMonHoc = b.TenMonHoc,
                              MoTa = b.MoTa,
                              TinhTrang = b.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("/ChiTietMonHoc")]
        public async Task<ActionResult> ChiTietMonHoc(int id)
        {
       
            var result = await _context.MonHoc.SingleOrDefaultAsync(n=> n.Id==id);
            
            return Ok(result);
        }

        [HttpGet]
        [Route("/ThemMonHocVaoLop")]
        public async Task<ActionResult> ThemMonHocVaoLop(int lh, int mh)
        {
            if(lh==0&&mh==0)
            {
                return NotFound();
            }
            var listLop = await _context.LopHoc.ToListAsync();
            var  a = new LopHocMonHoc();
            if(lh==0)
            {
                foreach(LopHoc l in listLop)
                {
                    a = new LopHocMonHoc();
                    a.LopHocId = l.Id;
                    a.MonHocId = mh;
                    try
                    {
                        _context.LopHocMonHoc.Add(a);
                        await _context.SaveChangesAsync();                     
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                
                return Ok("Da them vao tat ca lop hoc");
            }
            a.LopHocId = lh;
            a.MonHocId = mh;
            try
            {
                _context.LopHocMonHoc.Add(a);
              await  _context.SaveChangesAsync();
                
                return Ok(a);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Them thanh cong");


        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaMonHoc(int id,[FromBody] MonHoc monHoc)
        {
           
            if (id != monHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(monHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonHocExists(id))
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonHoc>> ThemMonHoc([FromBody] MonHoc monHoc)
        {
            _context.MonHoc.Add(monHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonHoc", new { id = monHoc.Id }, monHoc);
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaMonHoc(int id)
        {
            var monHoc = await _context.MonHoc.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.MonHoc.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonHocExists(int id)
        {
            return _context.MonHoc.Any(e => e.Id == id);
        }
    }
}
