using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public AmenController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/Amen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amen>>> GetAmen()
        {
          if (_context.Amen == null)
          {
              return NotFound();
          }
            return await _context.Amen.ToListAsync();
        }

        // GET: api/Amen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amen>> GetAmen(int id)
        {
          if (_context.Amen == null)
          {
              return NotFound();
          }
            var amen = await _context.Amen.FindAsync(id);

            if (amen == null)
            {
                return NotFound();
            }

            return amen;
        }

        // PUT: api/Amen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmen(int id, Amen amen)
        {
            if (id != amen.Id)
            {
                return BadRequest();
            }

            _context.Entry(amen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenExists(id))
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

        // POST: api/Amen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amen>> PostAmen(Amen amen)
        {
          if (_context.Amen == null)
          {
              return Problem("Entity set 'AsyncInnContext.Amen'  is null.");
          }
            _context.Amen.Add(amen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmen", new { id = amen.Id }, amen);
        }

        // DELETE: api/Amen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmen(int id)
        {
            if (_context.Amen == null)
            {
                return NotFound();
            }
            var amen = await _context.Amen.FindAsync(id);
            if (amen == null)
            {
                return NotFound();
            }

            _context.Amen.Remove(amen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmenExists(int id)
        {
            return (_context.Amen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
