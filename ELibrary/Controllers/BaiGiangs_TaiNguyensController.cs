using System;
using System.Collections.Generic;
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
    public class BaiGiangs_TaiNguyensController: ControllerBase
    {
        private readonly ELibraryDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BaiGiangs_TaiNguyensController(ELibraryDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        //
        [HttpGet]
        [Route("/BaiGiang")]
        public async Task<ActionResult> GetBaiGiang()
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where a.LoaiTaiLieu == "Bài giảng"
                          select new
                          {
                              Ten = a.TenTaiLieu,
                              Mon = b.TenMonHoc,
                              NguoiChinhSua = a.NguoiChinhSuaCuoi,
                              KichThuoc = a.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/LocBaiGiang")]
        public async Task<ActionResult> LocBaiGiang(int mh)
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where a.LoaiTaiLieu == "Bài giảng" && b.Id == mh
                          select new
                          {
                              Ten = a.TenTaiLieu,
                              Mon = b.TenMonHoc,
                              NguoiChinhSua = a.NguoiChinhSuaCuoi,
                              KichThuoc = a.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/TimKiemBaiGiang")]
        public async Task<ActionResult> TimKiemBaiGiang(string tukhoa)
        {
            tukhoa = tukhoa.ToLower();

            var taiLieu = await _context.TaiLieu.Where(m => m.TieuDe.ToLower().Contains(tukhoa)).ToListAsync();
            var result = (from a in taiLieu
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where a.LoaiTaiLieu == "Bài giảng"
                          select new
                          {
                              Ten = a.TenTaiLieu,
                              Mon = b.TenMonHoc,
                              NguoiChinhSua = a.NguoiChinhSuaCuoi,
                              KichThuoc = a.KichThuoc
                          }).ToList();
            return Ok(result);
        }
        //a

        //
        [HttpGet]
        [Route("/TaiNguyen")]
        public async Task<ActionResult> GetTaiNguyen()
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where a.LoaiTaiLieu == "Tài nguyên"
                          select new
                          {
                              Ten = a.TenTaiLieu,
                              Mon = b.TenMonHoc,
                              NguoiChinhSua = a.NguoiChinhSuaCuoi,
                              KichThuoc = a.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/LocTaiNguyen")]
        public async Task<ActionResult> LocTaiNguyen(int mh)
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where a.LoaiTaiLieu == "Tài nguyên" && a.MonHocId == mh
                          select new
                          {
                              Ten = a.TenTaiLieu,
                              Mon = b.TenMonHoc,
                              NguoiChinhSua = a.NguoiChinhSuaCuoi,
                              KichThuoc = a.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/TimKiemTaiNguyen")]
        public async Task<ActionResult> TimKiemTaiNguyen(string tukhoa)
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where a.LoaiTaiLieu == "Tài nguyên" && (b.TenMonHoc.Contains(tukhoa) || a.TieuDe.Contains(tukhoa))
                          select new
                          {
                              Ten = a.TenTaiLieu,
                              Mon = b.TenMonHoc,
                              NguoiChinhSua = a.NguoiChinhSuaCuoi,
                              KichThuoc = a.KichThuoc
                          }).ToList();
            return Ok(result);
        }
        [HttpPost]
        [Route("/ThemBaiGiang")]
        public async Task<IActionResult> ThemBaiGiang([FromBody] TaiLieu taiLieu)
        {
            taiLieu.LoaiTaiLieu = "Bài giảng";
            return await ThemTaiLieu(taiLieu);
        }
        //Them tai nguyen
        [HttpPost]
        [Route("/ThemTaiNguyen")]
        public async Task<IActionResult> ThemTaiNguyen([FromForm] TaiLieu taiLieu)
        {
            taiLieu.LoaiTaiLieu = "Tài nguyên";
            return await ThemTaiLieu(taiLieu);

        }

        private async Task<IActionResult> ThemTaiLieu(TaiLieu taiLieu)
        {
            try
            {
                _context.TaiLieu.Add(taiLieu);
                _context.SaveChangesAsync();
                return Ok("Them thanh cong");
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }
    }
}
