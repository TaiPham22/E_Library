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
    public class MonHocsController : ControllerBase
    {
        private readonly IMonHocBUS _MonHocBUS;

        public MonHocsController(IMonHocBUS MonHocBUS)
        {
            _MonHocBUS = MonHocBUS;
        }
        [HttpGet]
        public ActionResult GetMonHoc()
        {
            return Ok(_MonHocBUS.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<MonHoc> GetMonHoc_id(int id)
        {
            return _MonHocBUS.Detail(id);
        }
        [HttpGet]
        public ActionResult GetAlias(string tukhoa)
        {
            return Ok(_MonHocBUS.GetAlias(tukhoa));
        }
        [HttpPut]
        public IActionResult SuaMonHoc([FromBody] MonHoc MonHoc)
        {
            return Ok(_MonHocBUS.Update(MonHoc));
        }

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemMonHoc")]
        public IActionResult ThemMonHoc([FromBody] MonHoc MonHoc)
        {
            return Ok(_MonHocBUS.Add(MonHoc));
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMonHoc(int id)
        {

            return Ok(_MonHocBUS.Delete(id));
        }


    }
}
