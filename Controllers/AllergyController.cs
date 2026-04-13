using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllergyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AllergyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergy>>> GetAll()
        {
            return await _context.Allergies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Allergy>> GetById(int id)
        {
            var allergy = await _context.Allergies.FindAsync(id);
            if (allergy == null) return NotFound();
            return allergy;
        }

        [HttpGet("bypatient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Allergy>>> GetByPatient(int patientId)
        {
            return await _context.Allergies
                .Where(a => a.IdPatient == patientId)
                .ToListAsync();
        }

        [HttpGet("bycabinet/{cabinetId}")]
        public async Task<ActionResult<IEnumerable<Allergy>>> GetByCabinet(int cabinetId)
        {
            return await _context.Allergies
                .Where(a => a.IdCabinet == cabinetId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Allergy>> Create(Allergy allergy)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == allergy.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {allergy.IdPatient} does not exist.");

            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = allergy.IdAllergy }, allergy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Allergy allergy)
        {
            if (id != allergy.IdAllergy) return BadRequest();

            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == allergy.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {allergy.IdPatient} does not exist.");

            _context.Entry(allergy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Allergies.AnyAsync(a => a.IdAllergy == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var allergy = await _context.Allergies.FindAsync(id);
            if (allergy == null) return NotFound();
            _context.Allergies.Remove(allergy);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}