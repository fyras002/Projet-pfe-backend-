using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Data;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseaseCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiseaseCategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseCategory>>> GetAll()
        {
            return await _context.DiseaseCategories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseCategory>> GetById(int id)
        {
            var category = await _context.DiseaseCategories.FindAsync(id);
            if (category == null) return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<DiseaseCategory>> Create(DiseaseCategory category)
        {
            _context.DiseaseCategories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = category.IdDC }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DiseaseCategory category)
        {
            if (id != category.IdDC) return BadRequest();
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.DiseaseCategories.FindAsync(id);
            if (category == null) return NotFound();
            _context.DiseaseCategories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}