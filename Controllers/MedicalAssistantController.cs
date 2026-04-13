using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalAssistantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicalAssistantController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalAssistant>>> GetAll()
        {
            return await _context.MedicalAssistants.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalAssistant>> GetById(int id)
        {
            var assistant = await _context.MedicalAssistants.FindAsync(id);
            if (assistant == null) return NotFound();
            return assistant;
        }

        [HttpGet("bycabinet/{cabinetId}")]
        public async Task<ActionResult<IEnumerable<MedicalAssistant>>> GetByCabinet(int cabinetId)
        {
            return await _context.MedicalAssistants
                .Where(a => a.IdCabinet == cabinetId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MedicalAssistant>> Create(MedicalAssistant assistant)
        {
            _context.MedicalAssistants.Add(assistant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = assistant.IdAssistant }, assistant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicalAssistant assistant)
        {
            if (id != assistant.IdAssistant) return BadRequest();

            _context.Entry(assistant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.MedicalAssistants.AnyAsync(a => a.IdAssistant == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var assistant = await _context.MedicalAssistants.FindAsync(id);
            if (assistant == null) return NotFound();
            _context.MedicalAssistants.Remove(assistant);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}