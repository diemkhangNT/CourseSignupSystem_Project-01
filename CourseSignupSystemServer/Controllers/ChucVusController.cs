using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseSignupSystemServer.Data;
using CourseSignupSystemServer.Models;
using CourseSignupSystemServer.Interfaces;

namespace CourseSignupSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVusController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IExistAlreadyService _existTenCV;
        public ChucVusController(ApiDbContext context, IExistAlreadyService existtencv)
        {
            _context = context;
            _existTenCV = existtencv;
        }

        // GET: api/ChucVus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVu>>> GetChucVus()
        {
          if (_context.ChucVus == null)
          {
              return NotFound();
          }
            return await _context.ChucVus.ToListAsync();
        }

        // GET: api/ChucVus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVu>> GetChucVu(string id)
        {
          if (_context.ChucVus == null)
          {
              return NotFound();
          }
            var chucVu = await _context.ChucVus.FindAsync(id);

            if (chucVu == null)
            {
                return NotFound();
            }

            return chucVu;
        }

        // PUT: api/ChucVus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucVu(string id, ChucVu chucVu)
        {
            if (id != chucVu.MaCV)
            {
                return BadRequest();
            }

            _context.Entry(chucVu).State = EntityState.Modified;

            try
            {
                if (_existTenCV.IsTenCVUnique(chucVu.TenCV))
                {
                    return BadRequest("Tên chức vụ này đã tồn tại!");
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucVuExists(id))
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

        // POST: api/ChucVus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChucVu>> PostChucVu(ChucVu chucVu)
        {
          if (_context.ChucVus == null)
          {
              return Problem("Entity set 'ApiDbContext.ChucVus'  is null.");
          }
            _context.ChucVus.Add(chucVu);
            try
            {
                if(_existTenCV.IsTenCVUnique(chucVu.TenCV))
                {
                    return BadRequest("Tên chức vụ này đã tồn tại!");
                }
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChucVuExists(chucVu.MaCV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChucVu", new { id = chucVu.MaCV }, chucVu);
        }

        // DELETE: api/ChucVus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChucVu(string id)
        {
            if (_context.ChucVus == null)
            {
                return NotFound();
            }
            var chucVu = await _context.ChucVus.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            _context.ChucVus.Remove(chucVu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChucVuExists(string id)
        {
            return (_context.ChucVus?.Any(e => e.MaCV == id)).GetValueOrDefault();
        }

    }
}
