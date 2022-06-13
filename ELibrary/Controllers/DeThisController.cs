using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELibrary.Model;
using static System.Net.Mime.MediaTypeNames;

namespace ELibrary.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DeThisController : ControllerBase
    {
        private readonly ELibraryDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeThisController(ELibraryDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

       

        // GET: api/DeThis/5
        [HttpGet]
        [Route("/ChiTietDeThi/{id}")]
        public async Task<ActionResult<DeThi>> DeThi_id(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);

            var result = (from a in _context.DeThi
                          join b in _context.TaiKhoan on a.TaiKhoanId equals b.Id
                          join c in _context.MonHoc on a.MonHocId equals c.Id
                          where a.Id==id
                          select new { 
                              MonHoc=c.TenMonHoc,
                              ThoiLuong=a.ThoiLuong,
                              TenDeThi=a.TenDeThi,
                              HinhThuc=a.HinhThuc,
                              GiaoVienDaoTao=b.UserName
                          }).ToList();

            if (deThi == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        //chitiet

        [HttpGet]
        [Route("/ChiTietDeThi")]
        public async Task<ActionResult> ChiTietDeThi(int deThi)
        {
            var result = (from a in _context.DeThi
                      join b in _context.TaiKhoan on a.TaiKhoanId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      where a.Id==deThi
                      select new
                      {
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.UserName,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          NgayTao = a.NgayTao,
                          TinhTrang = a.TinhTrang==null?"Dang cho phe duyet":(a.TinhTrang==true?"Da phe duyet":"Da huy")

                      }).ToList();
            return Ok(result);
        }
        //Duyet
        [HttpGet]
        [Route("/DuyetDeThi")]
        public async Task<ActionResult<DeThi>> DuyetDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null || HttpContext.Session.GetInt32("VaiTro") != 1)
            {
                return NotFound();
            }
            deThi.TinhTrang = true;
            deThi.NguoiPheDuyet = int.Parse(HttpContext.Session.GetString("Id"));
            _context.Update(deThi);
            await _context.SaveChangesAsync();
            return deThi;
        }
        //Duyet
        [HttpGet]
        [Route("/HuyDuyetDeThi")]
        public async Task<ActionResult<DeThi>> HuyDuyetDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null || HttpContext.Session.GetInt32("VaiTro") != 1)
            {
                return NotFound();
            }
            deThi.TinhTrang = false;
            deThi.NguoiPheDuyet = int.Parse(HttpContext.Session.GetString("Id"));
            _context.Update(deThi);
            await _context.SaveChangesAsync();
            return deThi;
        }

        //

        [HttpGet]
        [Route("/NganHangDethi")]
        public async Task<ActionResult> NganHangDeThi() //admin
        {

            var result = (from a in _context.DeThi
                      join b in _context.TaiKhoan on a.TaiKhoanId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      select new
                      {
                          LoaiFile=a.Loai,
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.UserName,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          TinhTrang = a.TinhTrang == null ? "Dang cho phe duyet" : (a.TinhTrang == true ? "Da phe duyet" : "Da huy")

                      }).ToList();

            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/Dethi")]
        public async Task<ActionResult> DsDeThi() //admin
        {

            var result = (from a in _context.DeThi
                      join b in _context.TaiKhoan on a.TaiKhoanId equals b.Id
                      select new
                      {
                          LoaiFile = a.Loai,
                          TenDeThi = a.TenDeThi,
                          ThoiLuong = a.ThoiLuong,
                          ThoiGianTao = a.NgayTao,
                          TinhTrang = a.TinhTrang == null ? "Dang cho phe duyet" : (a.TinhTrang == true ? "Da phe duyet" : "Da huy")

                      }).ToList();

            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/TimDeThi")]
        public async Task<ActionResult> TimDeThiKt(string tukhoa)
        {

            var result = (from a in _context.DeThi
                      join b in _context.TaiKhoan on a.TaiKhoanId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      where a.TenDeThi.Contains(tukhoa) || c.TenMonHoc.Contains(tukhoa)
                      select new
                      {
                          LoaiFile = a.Loai,
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.UserName,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          TinhTrang = a.TinhTrang == null ? "Dang cho phe duyet" : (a.TinhTrang == true ? "Da phe duyet" : "Da huy")

                      }).ToList();

            return Ok(result);
        }
        
        //
        [HttpGet]
        [Route("/LocDeThi")]
        public async Task<ActionResult> LocDsDethi(int bomon,int mon)
        {
            var x = await _context.BoMon.FindAsync(bomon);

            var result = (from a in _context.DeThi
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where b.BoMonId == bomon
                          select new
                          {
                              LoaiFile = a.Loai,
                              TenDeThi = a.TenDeThi,
                              ThoiLuong = a.ThoiLuong,
                              ThoiGianTao = a.NgayTao,
                              TinhTrang = a.TinhTrang == null ? "Dang cho phe duyet" : (a.TinhTrang == true ? "Da phe duyet" : "Da huy")
                          }).ToList();

            return Ok(result);
        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaDeThi(int id,[FromBody] DeThi deThi)
        {
            if (id != deThi.Id)
            {
                return BadRequest();
            }

            _context.Entry(deThi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeThiExists(id))
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
       


        // DELETE: api/DeThis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }

            _context.DeThi.Remove(deThi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeThiExists(int id)
        {
            return _context.DeThi.Any(e => e.Id == id);
        }
    }
}
