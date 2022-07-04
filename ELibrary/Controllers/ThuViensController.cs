using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using E_Library.Model;
using E_Library.BUS.IBUS;

namespace ELibrary.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ThuViensController : ControllerBase
    {
        private readonly IThuVienBUS _ThuVienBUS;

        public ThuViensController(IThuVienBUS ThuVienBUS)
        {
            _ThuVienBUS = ThuVienBUS;
        }
        [HttpGet]
        public ActionResult GetThuVien()
        {
            return Ok(_ThuVienBUS.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<ThuVien> GetThuVien_id(int id)
        {
            return _ThuVienBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaThuVien([FromBody] ThuVien ThuVien)
        {
            return Ok(_ThuVienBUS.Update(ThuVien));
        }

        // POST: api/ThuViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemThuVien")]
        public IActionResult ThemThuVien([FromBody] ThuVien ThuVien)
        {
            return Ok(_ThuVienBUS.Add(ThuVien));
        }

        // DELETE: api/ThuViens/5
        [HttpDelete("{id}")]
        public IActionResult DeleteThuVien(int id)
        {

            return Ok(_ThuVienBUS.Delete(id));
        }


    }
}
