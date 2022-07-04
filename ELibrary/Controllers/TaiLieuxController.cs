using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using E_Library.Model;
using E_Library.BUS.IBUS;


namespace ELibrary.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaiLieuxController : ControllerBase
    {
        private readonly E_LibraryDbContext _context;
        private readonly ITaiLieuBUS _TaiLieuBUS;


        public TaiLieuxController(E_LibraryDbContext context, ITaiLieuBUS taiLieu)
        {
            _context = context;
            _TaiLieuBUS = taiLieu;
        }

        // GET: api/TaiLieux
        [HttpGet]
        public ActionResult TaiLieu()
        {
            return Ok(_TaiLieuBUS.GetAll());
        }

        // GET: api/TaiLieux/5
        [HttpGet("{id}")]
        public ActionResult<TaiLieu> TaiLieu(int id)
        {
            return Ok(_TaiLieuBUS.Detail(id));
        }

        //
        [HttpGet]
        [Route("/TimKiemTaiLieu")]

        public async Task<ActionResult> TimKiemTaiLieu(string tukhoa)
        {
            
            return Ok(_TaiLieuBUS.GetAlias(tukhoa));
        }

        //
        //
        [HttpGet]
        [Route("/LocTaiLieu")]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> LocTaiLieu(int tth)
        {
            return Ok(_TaiLieuBUS.OrderBy(tth));
        }


        [HttpGet]
        [Route("/PheDuyetTaiLieu")]
        public async Task<ActionResult> DuyetTaiLieu(int TaiLieuId, bool tinhtrang)
        {
            return Ok(_TaiLieuBUS.PheDuyet(TaiLieuId,tinhtrang)) ;
        }

        // PUT: api/TaiLieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTaiLieu( [FromBody] TaiLieu taiLieu)
        {

            return Ok(_TaiLieuBUS.Update(taiLieu)) ;
        }
        //Phan cong
        [HttpPost]
        [Route("/PhanCongTaiLieu")]

        public async Task<ActionResult> PhanCongTaiLieu(int lopHoc, int tailieu)
        {
            
            return Ok(_TaiLieuBUS.AddLopHoc(tailieu,lopHoc));
        }

        //them tai lieu vao monhoc
        [HttpPost]
        [Route("/ThemTaiLieuVaoMonHoc")]
        public async Task<ActionResult> ThemVaoMonHoc(int taiLieu,int monHoc)
        {
            return Ok(_TaiLieuBUS.AddMonHoc(taiLieu,monHoc));
        }

        // DELETE: api/TaiLieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaTaiLieu(int id)
        {
            return Ok(_TaiLieuBUS.Delete(id));
        }

        private bool TaiLieuExists(int id)
        {
            return _context.TaiLieu.Any(e => e.Id == id);
        }
    }
}
