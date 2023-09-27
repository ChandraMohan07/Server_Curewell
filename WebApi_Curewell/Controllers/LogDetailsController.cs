using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogDetailsController : ControllerBase
    {
        private readonly CurewellDbContext _context;

        public LogDetailsController(CurewellDbContext context)
        {
            _context = context;
        }

        // GET: api/LogDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDetail>>> GetLogDetails()
        {
          if (_context.LogDetails == null)
          {
              return NotFound();
          }
            return await _context.LogDetails.ToListAsync();
        }

        // GET: api/LogDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogDetail>> GetLogDetail(string id)
        {
          if (_context.LogDetails == null)
          {
              return NotFound();
          }
            var logDetail = await _context.LogDetails.FindAsync(id);

            if (logDetail == null)
            {
                return NotFound();
            }

            return logDetail;
        }

        // PUT: api/LogDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogDetail(string id, LogDetail logDetail)
        {
            if (id != logDetail.UserName)
            {
                return BadRequest();
            }

            _context.Entry(logDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LogDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogDetail>> PostLogDetail(LogDetail logDetail)
        {
          if (_context.LogDetails == null)
          {
              return Problem("Entity set 'CurewellDbContext.LogDetails'  is null.");
          }
            _context.LogDetails.Add(logDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LogDetailExists(logDetail.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogDetail", new { id = logDetail.UserName }, logDetail);
        }

        // DELETE: api/LogDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogDetail(string id)
        {
            if (_context.LogDetails == null)
            {
                return NotFound();
            }
            var logDetail = await _context.LogDetails.FindAsync(id);
            if (logDetail == null)
            {
                return NotFound();
            }

            _context.LogDetails.Remove(logDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogDetailExists(string id)
        {
            return (_context.LogDetails?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
