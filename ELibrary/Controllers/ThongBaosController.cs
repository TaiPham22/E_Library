//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//using ELibrary.Model;

//namespace ELibrary.Controllers
//{
//    [Route("[controller]/[action]")]
//    [ApiController]
//    public class ThongBaosController : ControllerBase
//    {
//        private readonly ELibraryDbContext _context;

//        public ThongBaosController(ELibraryDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/ThongBaos
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ThongBao>>> DsThongBao()
//        {
//            return await _context.ThongBao.ToListAsync();
//        }

//        [HttpGet]
//        [Route("/LocThongBao")]
//        public async Task<ActionResult<IEnumerable<ThongBao>>> LocThongBao(int ?loai)
//        {
//            var result = await _context.ThongBao.ToListAsync();
//            if(loai==0)
//            {
//                result = result.Where(t => t.LoaiThongBao == true).ToList();
//            }else 
//                if(loai==1)
//            {
//                result = result.Where(t => t.LoaiThongBao == false).ToList();
//            }
            
//            return result;
//        }

//        [HttpGet]
//        [Route("/TimThongBao")]
//        public async Task<ActionResult<IEnumerable<ThongBao>>> TimThongBao(string tukhoa)
//        {
//            var result = (from tb in _context.ThongBao
//                          where tb.ChuDe.Contains(tukhoa) || tb.NoiDung.Contains(tukhoa)
//                          select new
//                          { }
//                          ).ToList();

//            return Ok(result);
//        }
//        // GET: api/ThongBaos/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ThongBao>> ThongBao(int id)
//        {
//            var result = await _context.ThongBao.FindAsync(id);

//            if (result == null)
//            {
//                return NotFound();
//            }

//            return result;
//        }

        

//        // POST: api/ThongBaos
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<ThongBao>> ThemThongBao([FromBody] ThongBao thongBao)
//        {
//            thongBao.ThoiGian = DateTime.Now;
//            _context.ThongBao.Add(thongBao);
//            await _context.SaveChangesAsync();

//            return Ok("Them thanh cong");
//        }

//        // DELETE: api/ThongBaos/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteThongBao(int id)
//        {
//            var thongBao = await _context.ThongBao.FindAsync(id);
//            if (thongBao == null)
//            {
//                return NotFound();
//            }

//            _context.ThongBao.Remove(thongBao);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ThongBaoExists(int id)
//        {
//            return _context.ThongBao.Any(e => e.Id == id);
//        }
//    }
//}
