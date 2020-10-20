using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiKeyStorageService.Data;
using ApiKeyStorageService.Model;
using Microsoft.Extensions.Logging;

namespace ApiKeyStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TornApiKeysController : ControllerBase
    {
        private readonly TornApiKeyContext _context;
        private readonly ILogger<TornApiKeysController> _logger;

        public TornApiKeysController(TornApiKeyContext context, ILogger<TornApiKeysController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/TornApiKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TornApiKey>>> GetTornApiKey()
        {
            _logger.LogInformation("Getting all TornApiKeys");
            return await _context.TornApiKey.Where(i => i.Enabled).ToListAsync().ConfigureAwait(false);
        }

        // GET: api/TornApiKeys/FactionApiKeys
        [HttpGet("FactionApiKeys")]
        public async Task<ActionResult<IEnumerable<TornApiKey>>> GetFactionApiKeys()
        {
            return await _context.TornApiKey.Where(i => i.Enabled && i.TrackFaction).ToListAsync().ConfigureAwait(false);
        }

        // GET: api/TornApiKeys/PlayerApiKeys
        [HttpGet("PlayerApiKeys")]
        public async Task<ActionResult<IEnumerable<TornApiKey>>> GetPlayerApiKeys()
        {
            return await _context.TornApiKey.Where(i => i.Enabled && i.TrackPlayer).ToListAsync().ConfigureAwait(false);
        }

        // GET: api/TornApiKeys/CompanyApiKeys
        [HttpGet("CompanyApiKeys")]
        public async Task<ActionResult<IEnumerable<TornApiKey>>> GetCompanyApiKeys()
        {
            return await _context.TornApiKey.Where(i => i.Enabled && i.TrackCompany).ToListAsync().ConfigureAwait(false);
        }

        // GET: api/TornApiKeys/TornApiKeys
        [HttpGet("TornTrackingApiKeys")]
        public async Task<ActionResult<IEnumerable<TornApiKey>>> GetTornApiKeys()
        {
            return await _context.TornApiKey.Where(i => i.Enabled && i.TrackTorn).ToListAsync().ConfigureAwait(false);
        }

        // GET: api/TornApiKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TornApiKey>> GetTornApiKey(int id)
        {
            var tornApiKey = await _context.TornApiKey.FindAsync(id).ConfigureAwait(false);

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
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Error attempting to PUT {0}", id);
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
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return CreatedAtAction("GetTornApiKey", new { id = tornApiKey.PlayerId }, tornApiKey);
        }

        // DELETE: api/TornApiKeys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TornApiKey>> DeleteTornApiKey(int id)
        {
            var tornApiKey = await _context.TornApiKey.FindAsync(id).ConfigureAwait(false);
            if (tornApiKey == null)
            {
                return NotFound();
            }

            _context.TornApiKey.Remove(tornApiKey);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return tornApiKey;
        }

        private bool TornApiKeyExists(int id)
        {
            return _context.TornApiKey.Any(e => e.PlayerId == id);
        }
    }
}
