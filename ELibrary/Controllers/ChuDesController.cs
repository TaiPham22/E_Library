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
    public class ChuDesController : ControllerBase
    {
        private readonly IChuDeBUS _chudeBUS;

        public ChuDesController(IChuDeBUS chudeBUS)
        {
            _chudeBUS = chudeBUS;
        }
        [HttpGet]
        public ActionResult GetChuDe()
        {
            return Ok(_chudeBUS.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<ChuDe> GetChuDe_id(int id)
        {
            return _chudeBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaChuDe([FromBody] ChuDe chuDe)
        {
            return Ok(_chudeBUS.Update(chuDe));
        }

        // POST: api/ChuDes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemChuDe")]
        public IActionResult ThemChuDe([FromBody] string chuDe)
        {
            return Ok(_chudeBUS.Add(chuDe));
        }

        // DELETE: api/ChuDes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteChuDe(int id)
        {

            return Ok(_chudeBUS.Delete(id));
        }


    }
}
