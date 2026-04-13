using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SymptomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SymptomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetAll()
        {
            return await _context.Symptoms.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Symptom>> GetById(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null) return NotFound();
            return symptom;
        }

        [HttpGet("bypatient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetByPatient(int patientId)
        {
            return await _context.Symptoms
                .Where(s => s.IdPatient == patientId)
                .ToListAsync();
        }

        [HttpGet("bycabinet/{cabinetId}")]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetByCabinet(int cabinetId)
        {
            return await _context.Symptoms
                .Where(s => s.IdCabinet == cabinetId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Symptom>> Create(Symptom symptom)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == symptom.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {symptom.IdPatient} does not exist.");

            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = symptom.IdSymptom }, symptom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Symptom symptom)
        {
            if (id != symptom.IdSymptom) return BadRequest();

            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == symptom.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {symptom.IdPatient} does not exist.");

            _context.Entry(symptom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Symptoms.AnyAsync(s => s.IdSymptom == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null) return NotFound();
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}