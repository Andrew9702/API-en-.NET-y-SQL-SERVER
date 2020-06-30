using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiASP.Models;

namespace RestApiASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevistasController : ControllerBase
    {
        private readonly BaseContext _context;

        public RevistasController(BaseContext context)
        {
            _context = context;
        }

        // GET: api/Revistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revista>>> GetRevistas()
        {
            return await _context.Revistas.ToListAsync();
        }

        // GET: api/Revistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revista>> GetRevista(long id)
        {
            var revista = await _context.Revistas.FindAsync(id);

            if (revista == null)
            {
                return NotFound();
            }

            return revista;
        }

        // PUT: api/Revistas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevista(long id, Revista revista)
        {
            if (id != revista.Id)
            {
                return BadRequest();
            }

            _context.Entry(revista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevistaExists(id))
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

        // POST: api/Revistas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Revista>> PostRevista(Revista revista)
        {
            _context.Revistas.Add(revista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevista", new { id = revista.Id }, revista);
        }

        // DELETE: api/Revistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Revista>> DeleteRevista(long id)
        {
            var revista = await _context.Revistas.FindAsync(id);
            if (revista == null)
            {
                return NotFound();
            }

            _context.Revistas.Remove(revista);
            await _context.SaveChangesAsync();

            return revista;
        }

        private bool RevistaExists(long id)
        {
            return _context.Revistas.Any(e => e.Id == id);
        }
    }
}
