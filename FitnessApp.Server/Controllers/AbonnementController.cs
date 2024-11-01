using FitnessApp.Server.Data;
using FitnessApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonnementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbonnementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonnement>>> GetAbonnements()
        {
            return await _context.Abonnements.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Abonnement>> GetAbonnement(int id)
        {
            var abonnement = await _context.Abonnements.FindAsync(id);

            if (abonnement == null)
            {
                return NotFound();
            }

            return abonnement;
        }

        [HttpPost]
        public async Task<ActionResult<Abonnement>> PostAbonnement(Abonnement abonnement)
        {
            _context.Abonnements.Add(abonnement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAbonnement), new { id = abonnement.AbonnementId }, abonnement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbonnement(int id, Abonnement abonnement)
        {
            if (id != abonnement.AbonnementId)
            {
                return BadRequest();
            }

            _context.Entry(abonnement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonnementExists(id))
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
        public async Task<IActionResult> DeleteAbonnement(int id)
        {
            var abonnement = await _context.Abonnements.FindAsync(id);
            if (abonnement == null)
            {
                return NotFound();
            }

            _context.Abonnements.Remove(abonnement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbonnementExists(int id)
        {
            return _context.Abonnements.Any(e => e.AbonnementId == id);
        }
    }
}
