using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchroniskoPsy.Data;
using SchroniskoPsy.Models;

namespace SchroniskoPsy.Controllers
{
    
    public class PsiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PsiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Psies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Psy.Include(p => p.Schronisko);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Psies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Psy == null)
            {
                return NotFound();
            }

            var psy = await _context.Psy
                .Include(p => p.Schronisko)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (psy == null)
            {
                return NotFound();
            }

            return View(psy);
        }

        // GET: Psies/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["SchroniskoID"] = new SelectList(_context.Set<Schronisko>(), "Id", "Nazwa");
            return View();
        }

        // POST: Psies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Imie,Wiek,Charakter,Rasa,Plec,SchroniskoID")] Psy psy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(psy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SchroniskoID"] = new SelectList(_context.Set<Schronisko>(), "Id", "Id", psy.SchroniskoID);
            return View(psy);
        }

        // GET: Psies/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Psy == null)
            {
                return NotFound();
            }

            var psy = await _context.Psy.FindAsync(id);
            if (psy == null)
            {
                return NotFound();
            }
            ViewData["SchroniskoID"] = new SelectList(_context.Set<Schronisko>(), "Id", "Nazwa", psy.SchroniskoID);
            return View(psy);
        }

        // POST: Psies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Wiek,Charakter,Rasa,Plec,SchroniskoID")] Psy psy)
        {
            if (id != psy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(psy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PsyExists(psy.Id))
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
            ViewData["SchroniskoID"] = new SelectList(_context.Set<Schronisko>(), "Id", "Id", psy.SchroniskoID);
            return View(psy);
        }

        // GET: Psies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Psy == null)
            {
                return NotFound();
            }

            var psy = await _context.Psy
                .Include(p => p.Schronisko)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (psy == null)
            {
                return NotFound();
            }

            return View(psy);
        }

        // POST: Psies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Psy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Psy'  is null.");
            }
            var psy = await _context.Psy.FindAsync(id);
            if (psy != null)
            {
                _context.Psy.Remove(psy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PsyExists(int id)
        {
          return (_context.Psy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
