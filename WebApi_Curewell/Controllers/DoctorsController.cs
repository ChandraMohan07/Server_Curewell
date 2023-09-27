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
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorHelper _helper;

        public DoctorsController(DoctorHelper helper)
        {
            _helper = helper;
        }

        // GET: api/Doctors
        [HttpGet("GetAllDoctors")]
        public ActionResult<List<Doctor>> GetDoctors()
        {
            var doctors = _helper.GetAllDoctors();
            if (doctors == null)
            {
                return NotFound();
            }
            return doctors.ToList();
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            bool res = _helper.UpdateDoctorDetails(doctor);
            return Ok(res);
        }

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddDoctor")]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            bool res = _helper.AddDoctor(doctor);
            return Ok(res);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("DeleteDoctor")]
        public async Task<IActionResult> DeleteDoctor(Doctor doctor)
        {
            bool res = _helper.DeleteDoctor(doctor);
            return Ok(res);
        }
    }
}
