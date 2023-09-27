using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Curewell.DAL;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly SpecializationHelper _helper;

        public SpecializationsController(SpecializationHelper helper)
        {
            _helper = helper;
        }

        // GET: api/Specializations
        [HttpGet("GetAllSpecializations")]
        public ActionResult<List<Specialization>> GetSpecializations()
        {
            List<Specialization> specList = _helper.GetAllSpecializations();
            if (specList == null)
            {
                return NotFound();
            }
            return specList.ToList();
        }

        [HttpPost("AddSpecializations")]
        public async Task<ActionResult<Specialization>> PostDoctor(Specialization specialization)
        {
            bool res = _helper.AddSpecialization(specialization);
            return Ok(res);
        }
    }
}