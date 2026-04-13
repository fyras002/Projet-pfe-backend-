using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyRelationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FamilyRelationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyRelations>>> GetAll()
        {
            return await _context.FamilyRelations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyRelations>> GetById(int id)
        {
            var familyRelation = await _context.FamilyRelations.FindAsync(id);
            if (familyRelation == null) return NotFound();
            return familyRelation;
        }

        [HttpGet("bypatient/{patientId}")]
        public async Task<ActionResult<IEnumerable<FamilyRelations>>> GetByPatient(int patientId)
        {
            return await _context.FamilyRelations
                .Where(f => f.IdPatient == patientId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<FamilyRelations>> Create(FamilyRelations familyRelation)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == familyRelation.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {familyRelation.IdPatient} does not exist.");

            var patient2Exists = await _context.Patients.AnyAsync(p => p.IdPatient == familyRelation.IdPatient2);
            if (!patient2Exists)
                return BadRequest($"Patient with id {familyRelation.IdPatient2} does not exist.");

            _context.FamilyRelations.Add(familyRelation);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = familyRelation.IdFamily }, familyRelation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FamilyRelations familyRelation)
        {
            if (id != familyRelation.IdFamily) return BadRequest();

            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == familyRelation.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {familyRelation.IdPatient} does not exist.");

            var patient2Exists = await _context.Patients.AnyAsync(p => p.IdPatient == familyRelation.IdPatient2);
            if (!patient2Exists)
                return BadRequest($"Patient with id {familyRelation.IdPatient2} does not exist.");

            _context.Entry(familyRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.FamilyRelations.AnyAsync(f => f.IdFamily == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var familyRelation = await _context.FamilyRelations.FindAsync(id);
            if (familyRelation == null) return NotFound();
            _context.FamilyRelations.Remove(familyRelation);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}