using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Curewell.DAL;
using WebApi_Curewell.Models;

namespace CurewellApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSpecializationsController : ControllerBase
    {
        private readonly DoctorSpecializationHelper _helper;

        public DoctorSpecializationsController(DoctorSpecializationHelper helper)
        {
            _helper = helper;
        }

        // GET: api/DoctorSpecializations
        [HttpGet("GetDoctorsBySpecialization/{code}")]
        public ActionResult<List<Doctor>> GetDoctorSpecializations(string code)
        {
            List<Doctor> dsList = _helper.GetDoctorsBySpecialization(code);
            if (dsList == null) return NotFound();
            return dsList.ToList();
        }
    }
}
