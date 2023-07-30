using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseSignupSystemServer.Data;
using CourseSignupSystemServer.Models;

namespace CourseSignupSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhThusController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DoanhThusController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/DoanhThus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoanhThu>>> GetDoanhThus()
        {
          if (_context.DoanhThus == null)
          {
              return NotFound();
          }
            return await _context.DoanhThus.ToListAsync();
        }

        // GET: api/DoanhThus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoanhThu>> GetDoanhThu(string id)
        {
          if (_context.DoanhThus == null)
          {
              return NotFound();
          }
            var doanhThu = await _context.DoanhThus.FindAsync(id);

            if (doanhThu == null)
            {
                return NotFound();
            }

            return doanhThu;
        }

        // PUT: api/DoanhThus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoanhThu(string id, DoanhThu doanhThu)
        {
            if (id != doanhThu.MaDoanhThu)
            {
                return BadRequest();
            }

            _context.Entry(doanhThu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoanhThuExists(id))
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

        // POST: api/DoanhThus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoanhThu>> PostDoanhThu(DoanhThu doanhThu)
        {
          if (_context.DoanhThus == null)
          {
              return Problem("Entity set 'ApiDbContext.DoanhThus'  is null.");
          }
            _context.DoanhThus.Add(doanhThu);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DoanhThuExists(doanhThu.MaDoanhThu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDoanhThu", new { id = doanhThu.MaDoanhThu }, doanhThu);
        }

        // DELETE: api/DoanhThus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoanhThu(string id)
        {
            if (_context.DoanhThus == null)
            {
                return NotFound();
            }
            var doanhThu = await _context.DoanhThus.FindAsync(id);
            if (doanhThu == null)
            {
                return NotFound();
            }

            _context.DoanhThus.Remove(doanhThu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoanhThuExists(string id)
        {
            return (_context.DoanhThus?.Any(e => e.MaDoanhThu == id)).GetValueOrDefault();
        }
    }
}
