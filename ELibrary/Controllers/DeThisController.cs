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
    public class DeThisController : ControllerBase
    {
        private readonly IDeThiBUS _DeThiBUS;

        public DeThisController(IDeThiBUS DeThiBUS)
        {
            _DeThiBUS = DeThiBUS;
        }
        [HttpGet]
        public ActionResult GetDeThi()
        {
            return Ok(_DeThiBUS.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<DeThi> GetDeThi_id(int id)
        {
            return _DeThiBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaDeThi([FromBody] DeThi deThi)
        {
            return Ok(_DeThiBUS.Update(deThi));
        }

        // POST: api/DeThis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemDeThi")]
        public IActionResult ThemDeThi([FromBody] DeThi deThi)
        {
            return Ok(_DeThiBUS.Add(deThi));
        }

        // DELETE: api/DeThis/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDeThi(int id)
        {
            return Ok(_DeThiBUS.Delete(id));
        }

        [HttpPut]
        public IActionResult PheDuyet(int id, bool trangThai)
        {
            return Ok(_DeThiBUS.PheDuyet(id, trangThai));
        }


    }
}
