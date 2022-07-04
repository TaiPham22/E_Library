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
    public class TepRiengsController : ControllerBase
    {
        private readonly ITepRiengBUS _TepRiengBUS;

        public TepRiengsController(ITepRiengBUS TepRiengBUS)
        {
            _TepRiengBUS = TepRiengBUS;
        }
        [HttpGet]
        public ActionResult GetTepRieng()
        {
            return Ok(_TepRiengBUS.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<TepRieng> GetTepRieng_id(int id)
        {
            return _TepRiengBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaTepRieng([FromBody] TepRieng TepRieng)
        {
            return Ok(_TepRiengBUS.Update(TepRieng));
        }

        // POST: api/TepRiengs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemTepRieng")]
        public IActionResult ThemTepRieng([FromBody] TepRieng TepRieng)
        {
            return Ok(_TepRiengBUS.Add(TepRieng));
        }

        // DELETE: api/TepRiengs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTepRieng(int id)
        {

            return Ok(_TepRiengBUS.Delete(id));
        }


    }
}
