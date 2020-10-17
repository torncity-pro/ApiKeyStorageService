using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiKeyStorageService.Data;
using ApiKeyStorageService.Model;

namespace ApiKeyStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TornApiKeysController : ControllerBase
    {
        private readonly TornApiKeyContext _context;

        public TornApiKeysController(TornApiKeyContext context)
        {
            _context = context;
        }

        // GET: api/TornApiKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TornApiKey>>> GetTornApiKey()
        {
            return await _context.TornApiKey.ToListAsync();
        }

        // GET: api/TornApiKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TornApiKey>> GetTornApiKey(int id)
        {
            var tornApiKey = await _context.TornApiKey.FindAsync(id);

            if (tornApiKey == null)
            {
                return NotFound();
            }

            return tornApiKey;
        }

        // PUT: api/TornApiKeys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTornApiKey(int id, TornApiKey tornApiKey)
        {
            if (id != tornApiKey.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(tornApiKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TornApiKeyExists(id))
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

        // POST: api/TornApiKeys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TornApiKey>> PostTornApiKey(TornApiKey tornApiKey)
        {
            _context.TornApiKey.Add(tornApiKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTornApiKey", new { id = tornApiKey.PlayerId }, tornApiKey);
        }

        // DELETE: api/TornApiKeys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TornApiKey>> DeleteTornApiKey(int id)
        {
            var tornApiKey = await _context.TornApiKey.FindAsync(id);
            if (tornApiKey == null)
            {
                return NotFound();
            }

            _context.TornApiKey.Remove(tornApiKey);
            await _context.SaveChangesAsync();

            return tornApiKey;
        }

        private bool TornApiKeyExists(int id)
        {
            return _context.TornApiKey.Any(e => e.PlayerId == id);
        }
    }
}
