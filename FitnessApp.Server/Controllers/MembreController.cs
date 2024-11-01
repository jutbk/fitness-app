using FitnessApp.Server.Data;
using FitnessApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MembreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Membre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membre>>> GetMembres()
        {
            return await _context.Membres.ToListAsync();
        }

        // GET: api/Membre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Membre>> GetMembre(int id)
        {
            var membre = await _context.Membres.FindAsync(id);

            if (membre == null)
            {
                return NotFound();
            }

            return membre;
        }

        // POST: api/Membre
        [HttpPost]
        public async Task<ActionResult<Membre>> PostMembre(Membre membre)
        {
            _context.Membres.Add(membre);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMembre), new { id = membre.MembreId }, membre);
        }

        // PUT: api/Membre/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembre(int id, Membre membre)
        {
            if (id != membre.MembreId)
            {
                return BadRequest();
            }

            _context.Entry(membre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembreExists(id))
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

        // DELETE: api/Membre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembre(int id)
        {
            var membre = await _context.Membres.FindAsync(id);
            if (membre == null)
            {
                return NotFound();
            }

            _context.Membres.Remove(membre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembreExists(int id)
        {
            return _context.Membres.Any(e => e.MembreId == id);
        }
    }
}
