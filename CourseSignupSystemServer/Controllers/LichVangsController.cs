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
    public class LichVangsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LichVangsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/LichVangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichVang>>> GetLichVangs()
        {
          if (_context.LichVangs == null)
          {
              return NotFound();
          }
            return await _context.LichVangs.ToListAsync();
        }

        // GET: api/LichVangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LichVang>> GetLichVang(string id)
        {
          if (_context.LichVangs == null)
          {
              return NotFound();
          }
            var lichVang = await _context.LichVangs.FindAsync(id);

            if (lichVang == null)
            {
                return NotFound();
            }

            return lichVang;
        }

        // PUT: api/LichVangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichVang(string id, LichVang lichVang)
        {
            if (id != lichVang.MaLop)
            {
                return BadRequest();
            }

            _context.Entry(lichVang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichVangExists(id))
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

        // POST: api/LichVangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LichVang>> PostLichVang(LichVang lichVang)
        {
          if (_context.LichVangs == null)
          {
              return Problem("Entity set 'ApiDbContext.LichVangs'  is null.");
          }
            _context.LichVangs.Add(lichVang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LichVangExists(lichVang.MaLop))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLichVang", new { id = lichVang.MaLop }, lichVang);
        }

        // DELETE: api/LichVangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichVang(string id)
        {
            if (_context.LichVangs == null)
            {
                return NotFound();
            }
            var lichVang = await _context.LichVangs.FindAsync(id);
            if (lichVang == null)
            {
                return NotFound();
            }

            _context.LichVangs.Remove(lichVang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LichVangExists(string id)
        {
            return (_context.LichVangs?.Any(e => e.MaLop == id)).GetValueOrDefault();
        }
    }
}
