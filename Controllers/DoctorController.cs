using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAll()
        {
            return await _context.Doctors
                .Include(d => d.Specialities)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetById(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Specialities)
                .Include(d => d.Consultations)
                .FirstOrDefaultAsync(d => d.IdDoctor == id);

            if (doctor == null) return NotFound();
            return doctor;
        }

        [HttpGet("bycabinet/{cabinetId}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetByCabinet(int cabinetId)
        {
            return await _context.Doctors
                .Include(d => d.Specialities)
                .Where(d => d.IdCabinet == cabinetId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = doctor.IdDoctor }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Doctor doctor)
        {
            if (id != doctor.IdDoctor) return BadRequest();

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Doctors.AnyAsync(d => d.IdDoctor == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return NotFound();
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}