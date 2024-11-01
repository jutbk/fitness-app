using FitnessApp.Server.Data;
using FitnessApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cours>>> GetCours()
        {
            return await _context.Cours.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cours>> GetCours(int id)
        {
            var cours = await _context.Cours.FindAsync(id);

            if (cours == null)
            {
                return NotFound();
            }

            return cours;
        }

        [HttpPost]
        public async Task<ActionResult<Cours>> PostCours(Cours cours)
        {
            _context.Cours.Add(cours);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCours), new { id = cours.CoursId }, cours);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCours(int id, Cours cours)
        {
            if (id != cours.CoursId)
            {
                return BadRequest();
            }

            _context.Entry(cours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCours(int id)
        {
            var cours = await _context.Cours.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            _context.Cours.Remove(cours);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursExists(int id)
        {
            return _context.Cours.Any(e => e.CoursId == id);
        }
    }
}
