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
    public class HocViensController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IExistAlreadyService _existEmail;

        public HocViensController(ApiDbContext context, IExistAlreadyService existEmail)
        {
            _context = context;
            _existEmail = existEmail;
        }

        // GET: api/HocViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocVien>>> GetHocViens()
        {
          if (_context.HocViens == null)
          {
              return NotFound();
          }
            return await _context.HocViens.ToListAsync();
        }

        // GET: api/HocViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocVien>> GetHocVien(string id)
        {
          if (_context.HocViens == null)
          {
              return NotFound();
          }
            var hocVien = await _context.HocViens.FindAsync(id);

            if (hocVien == null)
            {
                return NotFound();
            }

            return hocVien;
        }

        // PUT: api/HocViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocVien(string id, HocVien hocVien)
        {
            if (id != hocVien.MaHV)
            {
                return BadRequest();
            }

            _context.Entry(hocVien).State = EntityState.Modified;

            try
            {
                if(_existEmail.IsEmailHVUnique(hocVien.Email))
                {
                    return BadRequest("Email này đã tồn tại!");
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocVienExists(id))
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

        // POST: api/HocViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HocVien>> PostHocVien(HocVien hocVien)
        {
          if (_context.HocViens == null)
          {
              return Problem("Entity set 'ApiDbContext.HocViens'  is null.");
          }
            _context.HocViens.Add(hocVien);
            try
            {
                if (_existEmail.IsEmailHVUnique(hocVien.Email))
                {
                    return BadRequest("Email này đã tồn tại!");
                }
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HocVienExists(hocVien.MaHV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHocVien", new { id = hocVien.MaHV }, hocVien);
        }

        // DELETE: api/HocViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVien(string id)
        {
            if (_context.HocViens == null)
            {
                return NotFound();
            }
            var hocVien = await _context.HocViens.FindAsync(id);
            if (hocVien == null)
            {
                return NotFound();
            }

            _context.HocViens.Remove(hocVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocVienExists(string id)
        {
            return (_context.HocViens?.Any(e => e.MaHV == id)).GetValueOrDefault();
        }
    }
}
