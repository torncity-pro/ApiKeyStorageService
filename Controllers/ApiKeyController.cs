using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiKeyStorageService.Data;
using ApiKeyStorageService.Model;

namespace ApiKeyStorageService.Controllers
{
    public class ApiKeyController : Controller
    {
        private readonly TornApiKeyContext _context;

        public ApiKeyController(TornApiKeyContext context)
        {
            _context = context;
        }

        // GET: ApiKey
        public async Task<IActionResult> Index()
        {
            return View(await _context.TornApiKey.ToListAsync());
        }

        // GET: ApiKey/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornApiKey = await _context.TornApiKey
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (tornApiKey == null)
            {
                return NotFound();
            }

            return View(tornApiKey);
        }

        // GET: ApiKey/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApiKey/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,FactionId,CompanyId,ApiKey,Enabled,TrackPlayer,TrackFaction,TrackCompany,TrackTorn")] TornApiKey tornApiKey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tornApiKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tornApiKey);
        }

        // GET: ApiKey/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornApiKey = await _context.TornApiKey.FindAsync(id);
            if (tornApiKey == null)
            {
                return NotFound();
            }
            return View(tornApiKey);
        }

        // POST: ApiKey/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,FactionId,CompanyId,ApiKey,Enabled,TrackPlayer,TrackFaction,TrackCompany,TrackTorn")] TornApiKey tornApiKey)
        {
            if (id != tornApiKey.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tornApiKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TornApiKeyExists(tornApiKey.PlayerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tornApiKey);
        }

        // GET: ApiKey/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornApiKey = await _context.TornApiKey
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (tornApiKey == null)
            {
                return NotFound();
            }

            return View(tornApiKey);
        }

        // POST: ApiKey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tornApiKey = await _context.TornApiKey.FindAsync(id);
            _context.TornApiKey.Remove(tornApiKey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TornApiKeyExists(int id)
        {
            return _context.TornApiKey.Any(e => e.PlayerId == id);
        }
    }
}
