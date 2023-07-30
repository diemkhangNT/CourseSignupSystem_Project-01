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
    public class DiemsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DiemsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Diems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiems()
        {
          if (_context.Diems == null)
          {
              return NotFound();
          }
            return await _context.Diems.ToListAsync();
        }

        // GET: api/Diems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diem>> GetDiem(string id)
        {
          if (_context.Diems == null)
          {
              return NotFound();
          }
            var diem = await _context.Diems.FindAsync(id);

            if (diem == null)
            {
                return NotFound();
            }

            return diem;
        }

        // PUT: api/Diems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiem(string id, Diem diem)
        {
            if (id != diem.MaMH)
            {
                return BadRequest();
            }

            _context.Entry(diem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiemExists(id))
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

        // POST: api/Diems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diem>> PostDiem(Diem diem)
        {
          if (_context.Diems == null)
          {
              return Problem("Entity set 'ApiDbContext.Diems'  is null.");
          }
            _context.Diems.Add(diem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiemExists(diem.MaMH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiem", new { id = diem.MaMH }, diem);
        }

        // DELETE: api/Diems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiem(string id)
        {
            if (_context.Diems == null)
            {
                return NotFound();
            }
            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }

            _context.Diems.Remove(diem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiemExists(string id)
        {
            return (_context.Diems?.Any(e => e.MaMH == id)).GetValueOrDefault();
        }
    }
}
