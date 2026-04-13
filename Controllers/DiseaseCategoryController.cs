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

        // GET: api/diseasecategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseCategory>>> GetAll()
        {
            return await _context.DiseaseCategories.ToListAsync();
        }

        // GET: api/diseasecategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseCategory>> GetById(int id)
        {
            var category = await _context.DiseaseCategories.FindAsync(id);
            if (category == null) return NotFound();
            return category;
        }

        // POST: api/diseasecategory
        [HttpPost]
        public async Task<ActionResult<DiseaseCategory>> Create(DiseaseCategory category)
        {
            _context.DiseaseCategories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = category.IdDC }, category);
        }

        // PUT: api/diseasecategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DiseaseCategory category)
        {
            if (id != category.IdDC) return BadRequest();
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/diseasecategory/5
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