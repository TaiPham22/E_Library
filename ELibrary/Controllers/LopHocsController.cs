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
    public class LopHocsController : ControllerBase
    {
        private readonly ILopHocBUS _LopHocBUS;

        public LopHocsController(ILopHocBUS LopHocBUS)
        {
            _LopHocBUS = LopHocBUS;
        }
        [HttpGet]
        public ActionResult GetLopHoc()
        {
            return Ok(_LopHocBUS.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<LopHoc> GetLopHoc_id(int id)
        {
            return _LopHocBUS.Detail(id);
        }
        [HttpGet]
        public ActionResult GetAlias(string tukhoa)
        {
            return Ok(_LopHocBUS.GetAlias(tukhoa));
        }
        [HttpPut]
        public IActionResult SuaLopHoc([FromBody] LopHoc LopHoc)
        {
            return Ok(_LopHocBUS.Update(LopHoc));
        }

        // POST: api/LopHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemLopHoc")]
        public IActionResult ThemLopHoc([FromBody] LopHoc LopHoc)
        {
            return Ok(_LopHocBUS.Add(LopHoc));
        }

        // DELETE: api/LopHocs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLopHoc(int id)
        {

            return Ok(_LopHocBUS.Delete(id));
        }


    }
}
