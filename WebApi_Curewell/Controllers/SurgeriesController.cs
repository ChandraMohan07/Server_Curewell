using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Curewell.DAL;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeriesController : ControllerBase
    {
        private readonly SurgeryHelper _helper;

        public SurgeriesController(SurgeryHelper helper)
        {
            _helper = helper;
        }

        // GET: api/Surgeries
        [HttpGet("GetAllSurgeryTypeForToday")]
        public ActionResult<List<Surgery>> GetSurgeries()
        {
            List<Surgery> surgeryList = _helper.GetAllSurgeryTypeForToday();
            if (surgeryList == null)
            {
                return NotFound();
            }
            return surgeryList.ToList();
        }

        // PUT: api/Surgeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddSurgery")]
        public IActionResult PutSurgery(Surgery surgery)
        {
            bool res = _helper.AddSurgery(surgery);
            return Ok(res);
        }

        // POST: api/Surgeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSurgery")]
        public IActionResult PostSurgery(Surgery surgery)
        {
            bool res = _helper.UpdateSurgery(surgery);
            return Ok(res);
        }
    }
}
