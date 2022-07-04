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
    public class ThongBaosController : ControllerBase
    {
        private readonly IThongBaoBUS _ThongBaoBUS;

        public ThongBaosController(IThongBaoBUS ThongBaoBUS)
        {
            _ThongBaoBUS = ThongBaoBUS;
        }
        [HttpGet]
        public ActionResult GetThongBao(bool phanloai)
        {
            return Ok(_ThongBaoBUS.GetAll(phanloai));
        }
        [HttpGet]
        public ActionResult LocThongBao(bool phanloai)
        {
            return Ok(_ThongBaoBUS.OrderBy(phanloai));
        }
        [HttpGet]
        public ActionResult TimThongBao(string tukhoa,bool phanloai)
        {
            return Ok(_ThongBaoBUS.GetAlias(tukhoa,phanloai));
        }


        [HttpGet("{id}")]
        public ActionResult<ThongBao> GetThongBao_id(int id)
        {
            return _ThongBaoBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaThongBao([FromBody] ThongBao ThongBao)
        {
            return Ok(_ThongBaoBUS.Update(ThongBao));
        }

        // POST: api/ThongBaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemThongBao")]
        public IActionResult ThemThongBao([FromBody] ThongBao ThongBao)
        {
            return Ok(_ThongBaoBUS.Add(ThongBao));
        }

        // DELETE: api/ThongBaos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteThongBao(int id)
        {

            return Ok(_ThongBaoBUS.Delete(id));
        }


    }
}
