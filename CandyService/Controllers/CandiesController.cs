using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CandyService.Database;
using CandyService.Models;

namespace CandyService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CandiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Candies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candy>>> Getcandies()
        {
            return await _context.candies.ToListAsync();
        }

        // GET: api/Candies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candy>> GetCandy(int id)
        {
            var candy = await _context.candies.FindAsync(id);

            if (candy == null)
            {
                return NotFound();
            }

            return candy;
        }

        // PUT: api/Candies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandy(int id, Candy candy)
        {
            if (id != candy.Id)
            {
                return BadRequest();
            }

            _context.Entry(candy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandyExists(id))
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

        // POST: api/Candies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candy>> PostCandy(Candy candy)
        {
            _context.candies.Add(candy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandy", new { id = candy.Id }, candy);
        }

        // DELETE: api/Candies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandy(int id)
        {
            var candy = await _context.candies.FindAsync(id);
            if (candy == null)
            {
                return NotFound();
            }

            _context.candies.Remove(candy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandyExists(int id)
        {
            return _context.candies.Any(e => e.Id == id);
        }
    }
}
