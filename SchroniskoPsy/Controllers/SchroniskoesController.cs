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
    public class SchroniskoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchroniskoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schroniskoes
        public async Task<IActionResult> Index()
        {
              return _context.Schronisko != null ? 
                          View(await _context.Schronisko.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Schronisko'  is null.");
        }

        // GET: Schroniskoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schronisko == null)
            {
                return NotFound();
            }

            var schronisko = await _context.Schronisko
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schronisko == null)
            {
                return NotFound();
            }

            return View(schronisko);
        }

        // GET: Schroniskoes/Create
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schroniskoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Ulica,Miejscowosc,NumerTel")] Schronisko schronisko)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schronisko);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schronisko);
        }

        // GET: Schroniskoes/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Schronisko == null)
            {
                return NotFound();
            }

            var schronisko = await _context.Schronisko.FindAsync(id);
            if (schronisko == null)
            {
                return NotFound();
            }
            return View(schronisko);
        }

        // POST: Schroniskoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Ulica,Miejscowosc,NumerTel")] Schronisko schronisko)
        {
            if (id != schronisko.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schronisko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchroniskoExists(schronisko.Id))
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
            return View(schronisko);
        }

        // GET: Schroniskoes/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Schronisko == null)
            {
                return NotFound();
            }

            var schronisko = await _context.Schronisko
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schronisko == null)
            {
                return NotFound();
            }

            return View(schronisko);
        }

        // POST: Schroniskoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Schronisko == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Schronisko'  is null.");
            }
            var schronisko = await _context.Schronisko.FindAsync(id);
            if (schronisko != null)
            {
                _context.Schronisko.Remove(schronisko);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchroniskoExists(int id)
        {
          return (_context.Schronisko?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
