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
    public class KhoasController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IExistAlreadyService _existTenKhoa;

        public KhoasController(ApiDbContext context, IExistAlreadyService existTenKhoa)
        {
            _context = context;
            _existTenKhoa = existTenKhoa;
        }

        // GET: api/Khoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoa>>> GetKhoas()
        {
          if (_context.Khoas == null)
          {
              return NotFound();
          }
            return await _context.Khoas.ToListAsync();
        }

        // GET: api/Khoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khoa>> GetKhoa(string id)
        {
          if (_context.Khoas == null)
          {
              return NotFound();
          }
            var khoa = await _context.Khoas.FindAsync(id);

            if (khoa == null)
            {
                return NotFound();
            }

            return khoa;
        }

        // PUT: api/Khoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoa(string id, Khoa khoa)
        {
            if (id != khoa.MaKhoa)
            {
                return BadRequest();
            }

            _context.Entry(khoa).State = EntityState.Modified;

            try
            {
                if(_existTenKhoa.IsTenKhoaUnique(khoa.TenKhoa))
                {
                    return BadRequest("Tên khoa đã tồn tại!");
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaExists(id))
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

        // POST: api/Khoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khoa>> PostKhoa(Khoa khoa)
        {
          if (_context.Khoas == null)
          {
              return Problem("Entity set 'ApiDbContext.Khoas'  is null.");
          }
            _context.Khoas.Add(khoa);
            try
            {
                if (_existTenKhoa.IsTenKhoaUnique(khoa.TenKhoa))
                {
                    return BadRequest("Tên khoa đã tồn tại!");
                }
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KhoaExists(khoa.MaKhoa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhoa", new { id = khoa.MaKhoa }, khoa);
        }

        // DELETE: api/Khoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoa(string id)
        {
            if (_context.Khoas == null)
            {
                return NotFound();
            }
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }

            _context.Khoas.Remove(khoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaExists(string id)
        {
            return (_context.Khoas?.Any(e => e.MaKhoa == id)).GetValueOrDefault();
        }
    }
}
