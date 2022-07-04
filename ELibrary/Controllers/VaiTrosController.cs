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
    public class VaiTrosController : ControllerBase
    {
        private readonly IVaiTroBUS _VaiTroBUS;

        public VaiTrosController(IVaiTroBUS VaiTroBUS)
        {
            _VaiTroBUS = VaiTroBUS;
        }
        [HttpGet]
        public ActionResult GetVaiTro()
        {
            return Ok(_VaiTroBUS.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<VaiTro> GetVaiTro_id(int id)
        {
            return _VaiTroBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaVaiTro([FromBody] VaiTro VaiTro)
        {
            return Ok(_VaiTroBUS.Update(VaiTro));
        }

        // POST: api/VaiTros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemVaiTro")]
        public IActionResult ThemVaiTro([FromBody] VaiTro VaiTro)
        {
            return Ok(_VaiTroBUS.Add(VaiTro));
        }
        [HttpPost]
        [Route("/VaiTroPhanQuyen")]
        public IActionResult VaiTroPhanQuyen([FromBody] VaiTroPhanQuyen vaiTroPhanQuyen)
        {
            return Ok(_VaiTroBUS.VaiTroPhanQuyen(vaiTroPhanQuyen));
        }

        // DELETE: api/VaiTros/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVaiTro(int id)
        {

            return Ok(_VaiTroBUS.Delete(id));
        }


    }
}
