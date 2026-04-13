using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpecialityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/speciality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speciality>>> GetAll()
        {
            return await _context.Specialities.ToListAsync();
        }

        // GET: api/speciality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speciality>> GetById(int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) return NotFound();
            return speciality;
        }

        // POST: api/speciality
        [HttpPost]
        public async Task<ActionResult<Speciality>> Create(Speciality speciality)
        {
            _context.Specialities.Add(speciality);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = speciality.IdS }, speciality);
        }

        // PUT: api/speciality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Speciality speciality)
        {
            if (id != speciality.IdS) return BadRequest();
            _context.Entry(speciality).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/speciality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null) return NotFound();
            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}