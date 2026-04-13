using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiseaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetAll()
        {
            return await _context.Diseases.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetById(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null) return NotFound();
            return disease;
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Disease>>> GetByCategory(int categoryId)
        {
            var diseases = await _context.Diseases
                .Where(d => d.IdDC == categoryId)
                .ToListAsync();

            return diseases;
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Disease>>> GetActive()
        {
            return await _context.Diseases
                .Where(d => d.Active == 1)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Disease>> Create(Disease disease)
        {
            var categoryExists = await _context.DiseaseCategories
                .AnyAsync(dc => dc.IdDC == disease.IdDC);

            if (!categoryExists)
                return BadRequest($"DiseaseCategory with id {disease.IdDC} does not exist.");

            _context.Diseases.Add(disease);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = disease.IdDisease }, disease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Disease disease)
        {
            if (id != disease.IdDisease) return BadRequest();

            var categoryExists = await _context.DiseaseCategories
                .AnyAsync(dc => dc.IdDC == disease.IdDC);

            if (!categoryExists)
                return BadRequest($"DiseaseCategory with id {disease.IdDC} does not exist.");

            _context.Entry(disease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Diseases.AnyAsync(d => d.IdDisease == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null) return NotFound();
            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}