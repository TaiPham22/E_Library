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
    public class BoMonsController : ControllerBase
    {
        private readonly IBoMonBUS _bomonBUS;

        public BoMonsController(IBoMonBUS bomonBUS)
        {
            _bomonBUS = bomonBUS;
        }
        [HttpGet]
        public ActionResult GetBoMon()
        {
            return Ok(_bomonBUS.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<BoMon> GetBoMon_id(int id)
        {
            return _bomonBUS.Detail(id);
        }

        [HttpPut]
        public IActionResult SuaBoMon([FromBody] BoMon boMon)
        {
            return Ok(_bomonBUS.Update(boMon));
        }

        // POST: api/BoMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/ThemBoMon")]
        public IActionResult ThemBoMon([FromBody] string boMon)
        {
            return Ok(_bomonBUS.Add(boMon));
        }

        // DELETE: api/BoMons/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBoMon(int id)
        {

            return Ok(_bomonBUS.Delete(id));
        }

     
    }
}
