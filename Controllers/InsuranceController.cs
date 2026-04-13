using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsuranceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetAll()
        {
            return await _context.Insurances.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetById(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return NotFound();
            return insurance;
        }

        [HttpGet("bypatient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetByPatient(int patientId)
        {
            return await _context.Insurances
                .Where(i => i.IdPatient == patientId)
                .ToListAsync();
        }

        [HttpGet("bycabinet/{cabinetId}")]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetByCabinet(int cabinetId)
        {
            return await _context.Insurances
                .Where(i => i.IdCabinet == cabinetId)
                .ToListAsync();
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetActive()
        {
            return await _context.Insurances
                .Where(i => i.Active == 1)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Insurance>> Create(Insurance insurance)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == insurance.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {insurance.IdPatient} does not exist.");

            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = insurance.IdInsurance }, insurance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Insurance insurance)
        {
            if (id != insurance.IdInsurance) return BadRequest();

            var patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == insurance.IdPatient);
            if (!patientExists)
                return BadRequest($"Patient with id {insurance.IdPatient} does not exist.");

            _context.Entry(insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Insurances.AnyAsync(i => i.IdInsurance == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return NotFound();
            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}