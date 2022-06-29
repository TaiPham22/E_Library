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
    public class TroGiupsController : ControllerBase
    {
        private readonly ITroGiupBUS _TroGiupBUS;

        public TroGiupsController(ITroGiupBUS TroGiupBUS)
        {
            _TroGiupBUS = TroGiupBUS;
        }
        [HttpGet]
        public ActionResult GetTroGiup()
        {
            return Ok(_TroGiupBUS.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<TroGiup> GetTroGiup_id(int id)
        {
            return _TroGiupBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaTroGiup([FromBody] TroGiup TroGiup)
        {
            return Ok(_TroGiupBUS.Update(TroGiup));
        }

        // POST: api/TroGiups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemTroGiup")]
        public IActionResult ThemTroGiup([FromBody] TroGiup troGiup)
        {
            return Ok(_TroGiupBUS.Add(troGiup));
        }

        // DELETE: api/TroGiups/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTroGiup(int id)
        {

            return Ok(_TroGiupBUS.Delete(id));
        }


    }
}
