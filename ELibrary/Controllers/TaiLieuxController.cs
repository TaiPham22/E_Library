//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//using ELibrary.Model;

//namespace ELibrary.Controllers
//{
//    [Route("[controller]/[action]")]
//    [ApiController]
//    public class TaiLieuxController : ControllerBase
//    {
//        private readonly ELibraryDbContext _context;
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public TaiLieuxController(ELibraryDbContext context, IWebHostEnvironment webHostEnvironment)
//        {
//            _context = context;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        // GET: api/TaiLieux
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TaiLieu>>> TaiLieu()
//        {
//            return await _context.TaiLieu.ToListAsync();
//        }

//        // GET: api/TaiLieux/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TaiLieu>> TaiLieu(int id)
//        {
//            var taiLieu = await _context.TaiLieu.FindAsync(id);

//            if (taiLieu == null)
//            {
//                return NotFound();
//            }

//            return taiLieu;
//        }
       
//        //
//        [HttpGet]
//        [Route("/TimKiemTaiLieu")]

//        public async Task<ActionResult> TimKiemTaiLieu(string tukhoa)
//        {
//            var result = (from a in _context.TaiLieu
//                          join b in _context.LopHocTaiLieu on a.Id equals b.TaiLieuId
//                          join c in _context.LopHoc on b.LopHocId equals c.Id
//                          join d in _context.MonHoc on a.MonHocId equals d.Id
//                          where a.TieuDe.Contains(tukhoa) || c.TenLop.Contains(tukhoa) || d.TenMonHoc.Contains(tukhoa)
//                          select new
//                          {

//                              TenTaiLieu = a.TenTaiLieu,
//                              PhanLoai = a.LoaiTaiLieu,
//                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
//                              TinhTrangPheDuyet = a.TinhTrang,
//                              GhiChu = a.GhiChu
//                          }).ToList();
//            return Ok(result);
//        }
       
//        //
//        //
//        [HttpGet]
//        [Route("/LocTaiLieu")]
//        public async Task<ActionResult<IEnumerable<TaiLieu>>> LocTaiLieu(int? tt, string gv, int mh)
//        {
//            var result = await _context.TaiLieu.ToListAsync();
//            if (gv != null && mh != 0)
//            {
//                result = await _context.TaiLieu.Where(t => t.TaiKhoanId == gv && t.MonHocId == mh).ToListAsync();
//            }
//            else
//            if (mh != 0)
//            {
//                result = await _context.TaiLieu.Where(t => t.MonHocId == mh).ToListAsync();
//            }
//            else
//            if (gv != null)
//            {
//                result = await _context.TaiLieu.Where(t => t.TaiKhoanId == gv).ToListAsync();
//            }

//            if (tt != null)
//            {
//                result = result.Where(t => t.TinhTrang == (tt != 0) ? true : false).ToList();
//            }

//            return result;
//        }
       

//        [HttpGet]
//        [Route("/PheDuyetTaiLieu")]
//        public async Task<ActionResult> DuyetTaiLieu(int TaiLieuId)
//        {
//            var taiLieu = await _context.TaiLieu.FindAsync(TaiLieuId);
                
//            if (taiLieu == null)
//            {
//                return NotFound();
//            }
//            taiLieu.TinhTrang = true;
//            _context.Update(taiLieu);
//           await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        // PUT: api/TaiLieux/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> SuaTaiLieu(int id,[FromBody] TaiLieu taiLieu)
//        {
//            if (id != taiLieu.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(taiLieu).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TaiLieuExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }
//        //Phan cong
//        [HttpPost]
//        [Route("/PhanCongTaiLieu")]

//        public async Task<ActionResult> PhanCongTaiLieu(int lh,int tl)
//        {
//            LopHocTaiLieu lhtl = new LopHocTaiLieu();
//            lhtl.LopHocId = lh;
//            lhtl.TaiLieuId = tl;
//            _context.LopHocTaiLieu.Add(lhtl);
//           await _context.SaveChangesAsync();
//            return Ok("Da them vao lop hoc");
//        }
        
//        //them tai lieu vao monhoc
//        [HttpPost]
//        [Route("/ThemTaiLieuVaoMonHoc")]
//        public async Task<ActionResult> ThemVaoMonHoc(int taiLieu,string tieuDe,int monHoc, int lopHoc)
//        {
//            var tlieu = await _context.TaiLieu.FindAsync(taiLieu);
//            TaiLieu tl = new TaiLieu {
//                MonHocId = monHoc,
//                TaiKhoanId = tlieu.TaiKhoanId,
//                TinhTrang = true,
//                NgayGuiPheDuyet = tlieu.NgayGuiPheDuyet,
//                LoaiTaiLieu = tlieu.LoaiTaiLieu,
//                NguoiChinhSuaCuoi = tlieu.NguoiChinhSuaCuoi,
//                TieuDe = tieuDe,
//                };
           
//            return Ok(tl);
//        }

//        // DELETE: api/TaiLieux/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> XoaTaiLieu(int id)
//        {
//            var taiLieu = await _context.TaiLieu.FindAsync(id);
//            if (taiLieu == null)
//            {
//                return NotFound();
//            }

//            _context.TaiLieu.Remove(taiLieu);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool TaiLieuExists(int id)
//        {
//            return _context.TaiLieu.Any(e => e.Id == id);
//        }
//    }
//}
