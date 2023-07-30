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
    public class LuongsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LuongsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Luongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Luong>>> GetLuongs()
        {
          if (_context.Luongs == null)
          {
              return NotFound();
          }
            return await _context.Luongs.ToListAsync();
        }

        // GET: api/Luongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Luong>> GetLuong(string id)
        {
          if (_context.Luongs == null)
          {
              return NotFound();
          }
            var luong = await _context.Luongs.FindAsync(id);

            if (luong == null)
            {
                return NotFound();
            }

            return luong;
        }

        // PUT: api/Luongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLuong(string id, Luong luong)
        {
            if (id != luong.MaLuong)
            {
                return BadRequest();
            }

            _context.Entry(luong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuongExists(id))
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

        // POST: api/Luongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Luong>> PostLuong(Luong luong)
        {
          if (_context.Luongs == null)
          {
              return Problem("Entity set 'ApiDbContext.Luongs'  is null.");
          }
            _context.Luongs.Add(luong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LuongExists(luong.MaLuong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLuong", new { id = luong.MaLuong }, luong);
        }

        // DELETE: api/Luongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLuong(string id)
        {
            if (_context.Luongs == null)
            {
                return NotFound();
            }
            var luong = await _context.Luongs.FindAsync(id);
            if (luong == null)
            {
                return NotFound();
            }

            _context.Luongs.Remove(luong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LuongExists(string id)
        {
            return (_context.Luongs?.Any(e => e.MaLuong == id)).GetValueOrDefault();
        }
    }
}
