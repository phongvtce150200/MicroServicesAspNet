using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoneService.Database;
using StoneService.Models;

namespace StoneService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stone>>> Getstones()
        {
            return await _context.stones.ToListAsync();
        }

        // GET: api/Stones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stone>> GetStone(int id)
        {
            var stone = await _context.stones.FindAsync(id);

            if (stone == null)
            {
                return NotFound();
            }

            return stone;
        }

        // PUT: api/Stones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStone(int id, Stone stone)
        {
            if (id != stone.Id)
            {
                return BadRequest();
            }

            _context.Entry(stone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoneExists(id))
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

        // POST: api/Stones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stone>> PostStone(Stone stone)
        {
            _context.stones.Add(stone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStone", new { id = stone.Id }, stone);
        }

        // DELETE: api/Stones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStone(int id)
        {
            var stone = await _context.stones.FindAsync(id);
            if (stone == null)
            {
                return NotFound();
            }

            _context.stones.Remove(stone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoneExists(int id)
        {
            return _context.stones.Any(e => e.Id == id);
        }
    }
}
