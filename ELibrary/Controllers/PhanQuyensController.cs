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
    public class PhanQuyensController : ControllerBase
    {
        private readonly IPhanQuyenBUS _PhanQuyenBUS;

        public PhanQuyensController(IPhanQuyenBUS PhanQuyenBUS)
        {
            _PhanQuyenBUS = PhanQuyenBUS;
        }
        [HttpGet]
        public ActionResult GetPhanQuyen()
        {
            return Ok(_PhanQuyenBUS.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<PhanQuyen> GetPhanQuyen_id(int id)
        {
            return _PhanQuyenBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaPhanQuyen([FromBody] PhanQuyen PhanQuyen)
        {
            return Ok(_PhanQuyenBUS.Update(PhanQuyen));
        }

        // POST: api/PhanQuyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemPhanQuyen")]
        public IActionResult ThemPhanQuyen([FromBody] PhanQuyen PhanQuyen)
        {
            return Ok(_PhanQuyenBUS.Add(PhanQuyen));
        }

        // DELETE: api/PhanQuyens/5
        [HttpDelete("{id}")]
        public IActionResult DeletePhanQuyen(int id)
        {

            return Ok(_PhanQuyenBUS.Delete(id));
        }


    }
}
